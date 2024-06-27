using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum BattleState {START,STATUS, PLAYERTURN, ENEMYTURN,WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public GameObject enemyPrefab;
    public GameObject playerPrefab;

    [SerializeField] private TextMeshProUGUI textUI;

    public Card cardRef;

    public Transform enemySpawn;
    public Transform playerSpawn;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;


    private DamageEffect damage;
    [SerializeField] private GameManager gm;

    [SerializeField] private AudioSource[] enemiesHit;
    [SerializeField] private AudioSource[] enemiesAttack;

    bool isPlayerDead = false;
   
    Dragon playerD;
    Knight enemyK;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        textUI.text = ("Start Combat");
       
        StartCoroutine(SetupBattle());
    }

    public void PlayEnemyHitSound()
    {
        AudioSource hitNoise = enemiesHit[Random.Range(0, enemiesHit.Length)];
        hitNoise.Play();
    }
    public void EnemyAtackSound()
    {
        AudioSource Attacknoise = enemiesAttack[Random.Range(0, enemiesAttack.Length)];
        Attacknoise.Play();
    }

    public Card GetCardRef()
    {
        return cardRef;
    }

   IEnumerator  SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
        playerD = playerGO.GetComponent<Dragon>();
        
        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawn);
        enemyK = enemyGO.GetComponent<Knight>();
        enemyK.enemyHealth = enemyHUD.enemyHealth;

        playerHUD.SetupDragon(playerD);
        enemyHUD.SetupEnemy(enemyK);

        yield return new WaitForSeconds(1f);

        state = BattleState.STATUS;
        StartCoroutine(StatusTurn());
    }

    IEnumerator StatusTurn()
    {
        //check for status effects here

        textUI.text = "Checking for Statuses";

       
        yield return new WaitForSeconds(2f);
        StartCoroutine(PlayerTurn());
    }

    public void EndPlayerTurn()
    {
        state = BattleState.ENEMYTURN;
        textUI.text = "Enemies Turn";
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerTurn()
    {
        textUI.text = "Player's Turn";
        state = BattleState.PLAYERTURN;

        int playerHand = 4;
        for (int i = 0; i < playerHand; i++)
        {
            gm.DrawCard();
        }
       // StartCoroutine(PlayerAttack());
        yield return new WaitForSeconds(1f);
    }

    IEnumerator EnemyTurn()
    {
        int enemyDamage = Random.Range(1, 5);
        //Norbert AI Goes here
        textUI.text = "Enemies Attacking";
        EnemyAtackSound();
        yield return new WaitForSeconds(3f);
        playerHUD.UpdatePlayerHP(playerD.currentHP -= enemyDamage);
        if (playerD.currentHP <= 0)
        {
            isPlayerDead = true;
        }

        if (isPlayerDead)
        {
            state = BattleState.LOST;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = BattleState.STATUS;
            StartCoroutine(StatusTurn());
        }

    }
    
    IEnumerator EndBattle()
    {
        if (state == BattleState.WON)
        {
            textUI.text = "Vengenance not complete";
            yield return new WaitForSeconds(2f);
            LoadOverWorld();
        } else if (state == BattleState.LOST)
        {
            textUI.color = Color.red;
            textUI.text = "Dragons are Extinct";
            yield return new WaitForSeconds(3f);
            LoadMainMenu();
        }
    }

    public void EndTheBattle()
    {
        if (enemyK.currentHealth <= 0)
        {
            state = BattleState.WON;
        }
        else if (isPlayerDead)
        {
            state = BattleState.LOST;
        }
        StartCoroutine(EndBattle());
    }

    void LoadOverWorld()
    {
        SceneManager.LoadScene("HexGrid");
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}

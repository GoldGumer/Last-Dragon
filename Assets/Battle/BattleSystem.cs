using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BattleState {START,STATUS, PLAYERTURN, ENEMYTURN,WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public GameObject enemyPrefab;
    public GameObject playerPrefab;

    public TextMeshProUGUI textUI;

    public Card cardRef;

    public Transform enemySpawn;
    public Transform playerSpawn;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;


    [SerializeField] private DamageEffect damage;

    Dragon playerD;
    Knight enemyK;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        textUI.SetText("Start Combat");
        StartCoroutine(SetupBattle());
    }

   IEnumerator  SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
        playerD = playerGO.GetComponent<Dragon>();
        
        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawn);
        enemyK = enemyGO.GetComponent<Knight>();

        playerHUD.SetupDragon(playerD);
        enemyHUD.SetupEnemy(enemyK);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        StatusTurn();
    }

    void StatusTurn()
    {
        //check for status effects here

        textUI.text = "Checking for Statuses";

        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        //Damage Enemy
        bool isDead = enemyK.TakeDamage(damage.damageDealt);
        enemyHUD.UpdateEnemyHP(enemyK.currentHealth);

        textUI.text = "Performing: " + cardRef.name;

        yield return new WaitForSeconds(2f);

        //check if enemy is dead
        if (isDead)
        {
            //End Battle
            state = BattleState.WON;
            EndBattle();
        }
            //continue playing until player has hit end phase
    }
    public void EndPlayerTurn()
    {
        state = BattleState.ENEMYTURN;
        textUI.text = "Enemies Turn";
        StartCoroutine(EnemyTurn());
    }
    void PlayerTurn()
    {
        textUI.text = "Player's Turn";
    }
    IEnumerator PlayerHeal()
    {
        playerD.Heal(5);

        playerHUD.UpdatePlayerHP(playerD.currentHP);

        yield return new WaitForSeconds(1f);
    }
    IEnumerator PlayerShield()
    {
        playerD.Shield(3);

        playerHUD.UpdateShield(playerD.currentShield);

        yield return new WaitForSeconds (1f);
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }
    public void ShieldButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerShield());
    }

    IEnumerator EnemyTurn()
    {
        //Norbert AI Goes here
        textUI.text = "Enemies Attacking";

        yield return new WaitForSeconds(2f);
        bool isPlayerDead;
        //isPlayerDead = playerD.TakeDamage(enemyK CARD HERE) 

        playerHUD.UpdatePlayerHP(playerD.currentHP);

        yield return new WaitForSeconds(1f);

         /*(if (isPlayerDead)
        {
            state = BattleState.LOST
            EndBattle();
        }
         else 
         {
            state = BattleState.Status
            StatusTurn();
         }
          */
         
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            textUI.text = "Vengenance not complete";
            Invoke("LoadOverWorld", 2f);
        } else if (state == BattleState.LOST)
        {
            textUI.color = Color.red;
            textUI.text = "Dragons are Extinct";
            Invoke("LoadMainMenu", 3f);
        }
    }

    void LoadOverWorld()
    {
        SceneManager.LoadScene("Overworld");
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}

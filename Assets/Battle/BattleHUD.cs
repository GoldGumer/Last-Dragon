using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Slider enemyHealth;
    public TextMeshProUGUI playerHPtext;
    public TextMeshProUGUI playerMPtext;
    public TextMeshProUGUI playerShieldtext;

    public void SetupDragon(Dragon player)
    {
        playerHPtext.text = (player.maxHP.ToString());
        playerHPtext.text = (player.currentHP.ToString());

         
        playerShieldtext.text = (player.currentShield.ToString());
    }
    public void SetupEnemy(Knight enemy)
    {
        enemyHealth.maxValue = enemy.maxHealth;
        enemyHealth.value = enemy.currentHealth;
    }
    public void UpdatePlayerHP(int hp)
    {
        playerHPtext.SetText(hp.ToString());
    }
    public void UpdateEnemyHP(int hp)
    {
        enemyHealth.value = hp;
    }
    public void UpdateShield(int shield)
    {
        if (!playerShieldtext.IsActive()) {
            playerShieldtext.IsActive();
        }
        playerShieldtext.text = (shield.ToString());
    }
}

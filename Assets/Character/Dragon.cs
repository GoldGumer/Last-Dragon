using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Dragon : MonoBehaviour
{
    public int maxHP = 20;
    public int currentHP;

    public int currentShield = 0;
    public int maxShield = 5;
    [SerializeField] private int maxMana;
    [SerializeField] private int currentMana;

    public bool TakeDamage(int damage)
    {
        if (currentShield >= 0 && (damage - currentShield) >= 0)
        {
            damage -= currentShield;
            Shield(-currentShield);
            currentHP -= damage;
        }
        else if (currentShield > 0 && (currentShield - damage) > 0)
        {
            Shield(-damage);
        }

        GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>().playerHUD.UpdatePlayerHP(currentHP);
        
        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal(int amount)
    {
        if (currentHP < maxHP)
        {
            currentHP += amount;
        }
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>().playerHUD.UpdatePlayerHP(currentHP);
    }
    public void Shield(int amount)
    {
        currentShield += amount;
        if (currentShield > maxShield)
        {
            currentShield = maxShield;
        }

        GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>().playerHUD.UpdateShield(currentShield);
    }

    public int GetCurrentMana()
    {
        return currentMana;
    }

    public void LowerCurrentMana()
    {
        currentMana--;
        GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>().playerHUD.UpdatePlayerMP(currentMana);
    }

    public void ResetCurrentMana()
    {
        currentMana = maxMana;
        GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>().playerHUD.UpdatePlayerMP(currentMana);
    }
}

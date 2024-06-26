using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        currentHP -= damage;
        if (currentHP <= 0)
        {
            return true;
        }
        else
            return false;
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
    }
    public void Shield(int amount)
    {
        currentShield += amount;
        if (currentShield > maxShield)
        {
            currentShield = maxShield;
        }
    }
}

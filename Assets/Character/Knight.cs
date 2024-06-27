using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public Slider enemyHealth;

    public bool TakeDamage(int damage)
    {
        currentHealth -= damage;
        enemyHealth.value = currentHealth;
        if (currentHealth <= 0)
        {
            return true;
        }
        else
            return false;
        
    }
}

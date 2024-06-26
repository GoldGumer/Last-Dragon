using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider enemyHealth;

    public void SetHealth(int health)
    {
        enemyHealth.value = health;
    }

    public void SetMaxHealth(int max)
    {
        enemyHealth.maxValue = max;
        enemyHealth.value = max;
    }
}

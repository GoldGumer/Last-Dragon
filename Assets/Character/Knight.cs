using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{
    public enum Status
    {
        None,
        Poisoned
    }

    public int maxHealth = 5;
    public int currentHealth;
    private Status status = 0;

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

    public void ApplyStatus(Status status)
    {
        this.status = status;
    }

    public void DoStatusEffect()
    {
        switch (status)
        {
            case Status.Poisoned:
                if (TakeDamage(2))
                {
                    GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>().EndTheBattle();
                }
                break;
            default:
                break;
        }
    }
}

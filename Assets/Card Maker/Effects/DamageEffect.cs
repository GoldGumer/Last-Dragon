using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageEffect", menuName = "CardEffects/DamageEffect", order = 2)]
public class DamageEffect : Effect
{
    public EnemyHealth enemyHealth;
    public Effect cardValue;
    public int damageDealt;
    public override void DoEffect()
    {
        enemyHealth.SetHealth(-value);
    }

    public int DealDamage()
    {
        damageDealt = cardValue.GetCardValue();
        return damageDealt;
    }
}

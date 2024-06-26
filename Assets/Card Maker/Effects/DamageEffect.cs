using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageEffect", menuName = "CardEffects/DamageEffect", order = 2)]
public class DamageEffect : Effect
{
    public override void DoEffect()
    {
        GameObject knight = GameObject.FindGameObjectWithTag("Knight");
        
        if (knight)
        {
            if (knight.GetComponent<Knight>().TakeDamage(value))
            {
                GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>().EndTheBattle();
            }
        }
        
    }

}

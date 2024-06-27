using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomDamageEffect", menuName = "CardEffects/RandomDamageEffect", order = 4)]
public class RandomDamageEffect : Effect
{
    public override void DoEffect()
    {
        GameObject knight = GameObject.FindGameObjectWithTag("Knight");

        if (knight)
        {
            if (knight.GetComponent<Knight>().TakeDamage(Random.Range(1,(value + 1))))
            {
                GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>().EndTheBattle();
            }
        }
    }
}

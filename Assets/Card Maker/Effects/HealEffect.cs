using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealEffect", menuName = "CardEffects/HealEffect", order = 5)]
public class HealEffect : Effect
{
    public override void DoEffect()
    {
        GameObject dragon = GameObject.FindGameObjectWithTag("Player");

        if (dragon)
        {
            dragon.GetComponent<Dragon>().Heal(value);
        }   
    }
}

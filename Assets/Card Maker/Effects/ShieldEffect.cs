using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShieldEffect", menuName = "CardEffects/ShieldEffect", order = 4)]
public class ShieldEffect : Effect
{
    public override void DoEffect()
    {
        GameObject dragon = GameObject.FindGameObjectWithTag("Player");

        if (dragon)
        {
            dragon.GetComponent<Dragon>().Shield(value);
        }
    }
}

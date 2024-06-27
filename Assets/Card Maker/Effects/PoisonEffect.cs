using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonEffect", menuName = "CardEffects/PoisonEffect", order = 3)]
public class PoisonEffect : Effect
{
    public override void DoEffect()
    {
        GameObject knight = GameObject.FindGameObjectWithTag("Knight");

        if (knight)
        {
            knight.GetComponent<Knight>().ApplyStatus(Knight.Status.Poisoned);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveEffect", menuName = "CardEffects/MoveEffect", order = 1)]
public class MoveEffect : Effect
{
    [SerializeField] private int movement;

    public override void DoEffect()
    {
        DragonOverworld dragonOverworld = GameObject.FindGameObjectWithTag("Player").GetComponent<DragonOverworld>();

        if (dragonOverworld)
        {
            dragonOverworld.AddMovement(movement);
        }
    }
}

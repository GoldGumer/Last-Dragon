using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    [SerializeField] protected int value;
    [SerializeField] protected int maxNumberOfTargets;
    [SerializeField] protected string effectText;

    public string GetEffectText()
    {
        return effectText;
    }

    public int GetCardValue()
    {
        return value;
    }

    public abstract void DoEffect();
}

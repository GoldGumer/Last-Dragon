using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    protected enum targetTypes
    {
        ally,
        enemy
    }

    [SerializeField] protected int value;
    [SerializeField] protected targetTypes targetType;
    [SerializeField] protected int maxNumberOfTargets;
    [SerializeField] protected string effectText;

    public string GetEffectText()
    {
        return effectText;
    }

    public abstract void DoEffect();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADurationEffect : ScriptableObject
{
    [SerializeField]
    protected float duration = 5f;
    [SerializeField]
    protected int maxStacks = 1;
    [SerializeField]
    protected bool refreshesOnNewStack = true;
    [SerializeField]
    protected Sprite icon;
    [SerializeField, TextArea]
    private string description = "";

    protected DamagableObject owner = null;

    public float Duration => duration;
    public int MaxStacks => maxStacks;
    public bool RefreshesOnNewStack => refreshesOnNewStack;
    public Sprite Icon => icon;
    public string Description => description;

    public void SetOwner(DamagableObject _owner)
    {
        if(owner == null)
        {
            owner = _owner;
        }
    }

    public virtual void StartPersistentEffect() { }
    public virtual void StopPersistentEffect() { }
    public virtual void OnApplicationAndRefresh() { }
}

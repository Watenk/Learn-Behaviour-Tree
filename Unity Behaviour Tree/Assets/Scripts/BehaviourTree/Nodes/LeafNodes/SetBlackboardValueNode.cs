using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBlackboardValueNode<T> : LeafNode
{
    private string name;
    protected T value;

    public SetBlackboardValueNode(Blackboard blackboard, string name, T value) : base(blackboard) 
    {
        this.name = name;
        this.value = value;
    }

    public override BTState Tick()
    {
        base.Tick();

        UpdateValue();
        Blackboard.Set<T>(name, value);

        return BTState.tickNext;
    }

    public virtual void UpdateValue() { }
}

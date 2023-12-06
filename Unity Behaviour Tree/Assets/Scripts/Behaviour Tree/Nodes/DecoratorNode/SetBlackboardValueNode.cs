using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBlackboardValueNode<T> : DecoratorNode
{
    private string name;
    protected T value;

    public SetBlackboardValueNode(ITickable child, Blackboard blackboard, string name, T value) : base(child, blackboard) 
    {
        this.name = name;
        this.value = value;
    }

    public override BTState Tick()
    {
        UpdateValue();
        Blackboard.Set<T>(name, value);

        return child.Tick();
    }

    public virtual void UpdateValue() { }
}

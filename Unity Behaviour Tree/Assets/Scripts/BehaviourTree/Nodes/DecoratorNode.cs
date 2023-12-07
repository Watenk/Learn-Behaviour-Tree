using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Has a child and executes tick

public abstract class DecoratorNode : ITickable, IBlackboardable
{
    protected ITickable child;
    public Blackboard Blackboard { get; protected set; }

    public DecoratorNode(Blackboard blackboard, ITickable child)
    {
        Blackboard = blackboard;
        this.child = child;
    }

    public virtual BTState Tick()
    {
        Blackboard.Set<ITickable>("CurrentTickable", this);
        return BTState.dontReturnThis;
    }
}

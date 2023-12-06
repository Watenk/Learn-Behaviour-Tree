using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Has a child and executes tick

public abstract class DecoratorNode : MonoBehaviour, ITickable, IBlackboardable
{
    protected ITickable child;
    public Blackboard Blackboard { get; protected set; }

    public DecoratorNode(ITickable child, Blackboard blackboard)
    {
        this.child = child;
        Blackboard = blackboard;
    }


    public abstract BTState Tick();
}

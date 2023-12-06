using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just executes tick

public abstract class LeafNode : ITickable, IBlackboardable
{
    public Blackboard Blackboard { get; private set; }

    public LeafNode(Blackboard blackboard)
    {
        Blackboard = blackboard;
    }

    public abstract BTState Tick();
}

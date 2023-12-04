using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNode : ITickable, IBlackboardable
{
    public Blackboard Blackboard { get; set; }

    public virtual BTState Tick()
    {
        Blackboard.Set<string>("CurrentNode", this.ToString());

        return BTState.running;
    }
}

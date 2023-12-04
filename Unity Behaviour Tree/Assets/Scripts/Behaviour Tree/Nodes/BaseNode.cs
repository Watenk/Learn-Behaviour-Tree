using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNode : ITickable, IBlackboardable
{
    public Blackboard Blackboard { get; set; }

    public abstract BTState Tick();

    public void AssignBlackboard(Blackboard _blackboard)
    {
        Blackboard = _blackboard;
    }
}

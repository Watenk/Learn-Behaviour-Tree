using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTNode 
{
    protected Blackboard blackboard;

    public abstract BTState Tick();

    public void AssignBlackboard(Blackboard _blackboard)
    {
        blackboard = _blackboard;
    }
}

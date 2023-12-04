using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just executes all the children in order in a loop :)
public class ExecuteCompositeNode : BaseCompositeNode
{
    public override BTState TickCurrentTickable()
    {
        TickableList[TickableIndex].Tick();
        return BTState.running;
    }
}

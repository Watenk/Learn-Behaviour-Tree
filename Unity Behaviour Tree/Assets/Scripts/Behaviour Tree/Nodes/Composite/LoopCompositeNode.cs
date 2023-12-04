using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just executes all the children in order in a loop :)
public abstract class LoopCompositeNode : BaseCompositeNode
{
    public override BTState Tick()
    {
        base.Tick();

        return TickableList[TickableIndex].Tick();
    }
}

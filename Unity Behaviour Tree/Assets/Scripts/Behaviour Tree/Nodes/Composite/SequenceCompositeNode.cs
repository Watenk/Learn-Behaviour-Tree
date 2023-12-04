using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Runs all children until a node fails
public abstract class SequenceCompositeNode : BaseCompositeNode
{
    public override BTState Tick()
    {
        base.Tick();

        BTState state = TickableList[TickableIndex].Tick();

        if (state == BTState.failed)
        {
            TickableIndex = 0;
            return BTState.failed;
        }

        if (TickableIndex < TickableList.Count - 1)
        {
            TickableIndex++;
        }
        else
        {
            TickableIndex = 0;
        }

        return BTState.running;
    }
}

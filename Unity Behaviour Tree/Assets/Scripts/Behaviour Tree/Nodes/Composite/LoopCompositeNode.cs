using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Executes all the children in a loop :)
public abstract class LoopCompositeNode : BaseCompositeNode
{
    public override BTState Tick()
    {
        base.Tick();
        BTState state = TickableList[TickableIndex].Tick();

        if (state == BTState.succeeded)
        {
            if (TickableIndex < TickableList.Count - 1)
            {
                TickableIndex++;
            }
            else
            {
                TickableIndex = 0;
            }
        }

        return state;
    }
}

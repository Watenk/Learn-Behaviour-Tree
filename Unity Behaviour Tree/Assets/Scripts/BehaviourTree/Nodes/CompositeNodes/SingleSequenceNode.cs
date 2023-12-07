using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Runs all nodes once

public class SingleSequenceNode : CompositeNode
{
    public SingleSequenceNode(Blackboard blackboard, List<ITickable> tickables) : base(tickables, blackboard) { }

    public override BTState Tick()
    {
        BTState state = SequenceTick();

        if (TickableIndex == Tickables.Count - 1)
        {
            TickableIndex = 0;
            return BTState.succeeded;
        }

        if (state == BTState.succeeded)
        {
            SequenceAdvance();
        }

        if (state == BTState.tickNext)
        {
            SequenceAdvance();
            Tick();
        }

        return BTState.running;
    }

    public override void SequenceAdvance()
    {
        if (TickableIndex < Tickables.Count - 1)
        {
            TickableIndex++;
        }
    }
}

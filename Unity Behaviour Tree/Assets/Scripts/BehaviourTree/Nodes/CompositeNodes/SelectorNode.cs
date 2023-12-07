using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Runs until a node succeeds

public class SelectorNode : CompositeNode
{
    public SelectorNode(Blackboard blackboard, List<ITickable> tickables) : base(tickables, blackboard) { }

    public override BTState Tick()
    {
        BTState state = SequenceTick();

        if (state == BTState.succeeded)
        {
            return BTState.succeeded;
        }

        if (state == BTState.tickNext)
        {
            SequenceAdvance();
            Tick();
        }

        if (state == BTState.failed)
        {
            SequenceAdvance();
        }

        return BTState.running;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Runs until a node fails

public class SequenceNode : CompositeNode
{
    public SequenceNode(Blackboard blackboard, List<ITickable> tickables) : base(tickables, blackboard) { }

    public override BTState Tick()
    {
        BTState state = SequenceTick();

        if (state == BTState.succeeded)
        {
            SequenceAdvance();
        }

        if (state == BTState.tickNext)
        {
            SequenceAdvance();
            Tick();
        }

        if (state == BTState.failed)
        {
            return BTState.failed;
        }

        return BTState.running;
    }
}

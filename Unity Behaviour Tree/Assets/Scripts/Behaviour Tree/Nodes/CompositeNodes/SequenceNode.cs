using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Runs until a node fails

public class SequenceNode : CompositeNode
{
    public SequenceNode(List<ITickable> tickables, Blackboard blackboard) : base(tickables, blackboard) { }

    public override BTState Tick()
    {
        BTState state = SequenceTick();

        if (state == BTState.succeeded)
        {
            SequenceAdvance();
        }

        if (state == BTState.failed)
        {
            return BTState.failed;
        }

        return BTState.running;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Loops the sequence

public class RootNode : CompositeNode
{
    public RootNode(List<ITickable> tickables, Blackboard blackboard) : base(tickables, blackboard) { }

    public override BTState Tick()
    {
        BTState state = SequenceTick();

        if (state == BTState.succeeded)
        {
            SequenceAdvance();
        }

        return state;   
    }
}

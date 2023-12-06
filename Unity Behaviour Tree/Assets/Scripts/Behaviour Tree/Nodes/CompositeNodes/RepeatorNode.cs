using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatorNode : CompositeNode
{
    public RepeatorNode(List<ITickable> tickables, Blackboard blackboard) : base(tickables, blackboard) { }

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

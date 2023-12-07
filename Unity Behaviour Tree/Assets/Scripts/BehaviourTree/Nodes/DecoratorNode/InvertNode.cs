using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertNode : DecoratorNode
{
    public InvertNode(Blackboard blackboard, ITickable child) : base(blackboard, child) { }

    public override BTState Tick()
    {
        base.Tick();
        BTState state = child.Tick();

        if (state == BTState.succeeded)
        {
            return BTState.failed;
        }

        if (state == BTState.failed)
        {
            return BTState.succeeded;
        }

        return BTState.running;
    }
}

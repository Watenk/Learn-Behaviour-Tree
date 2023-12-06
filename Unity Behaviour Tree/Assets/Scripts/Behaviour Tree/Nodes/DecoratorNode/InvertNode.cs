using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertNode : DecoratorNode
{
    public InvertNode(ITickable child, Blackboard blackboard) : base(child, blackboard) { }

    public override BTState Tick()
    {
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

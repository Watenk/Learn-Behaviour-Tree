using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedNode : WaitNode
{
    public StunnedNode(Blackboard blackboard, float lenght) : base(blackboard, lenght)
    {
    }

    public override BTState Tick()
    {
        BTState state = base.Tick();
        if (state == BTState.succeeded)
        {
            Blackboard.Set<bool>("Stunned", false);
        }
        return state;
    }
}

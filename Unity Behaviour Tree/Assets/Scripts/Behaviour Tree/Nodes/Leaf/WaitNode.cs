using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitNode : BaseNode
{
    private int waitedTicks;
    private int waitAmount;

    public override BTState Tick()
    {
        base.Tick();

        waitedTicks += 1;

        if (waitedTicks >= waitAmount)
        {
            waitedTicks = 0;
            return BTState.succeeded;
        }

        return BTState.running;
    }

    public void SetWaitTime(int _amount)
    {
        waitAmount = _amount;
    }
}

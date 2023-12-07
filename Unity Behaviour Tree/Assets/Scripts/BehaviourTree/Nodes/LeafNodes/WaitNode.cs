using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitNode : LeafNode
{
    private float lenght;
    private float timer;

    public WaitNode(Blackboard blackboard, float lenght) : base(blackboard)
    {
        this.lenght = lenght;
    }

    public override BTState Tick()
    {
        base.Tick();

        timer += Time.deltaTime;

        if (timer >= lenght)
        {
            timer = 0;
            return BTState.succeeded;
        }

        return BTState.running;
    }

    public void SetLenght(float newLenght)
    {
        lenght = newLenght; 
    }
}

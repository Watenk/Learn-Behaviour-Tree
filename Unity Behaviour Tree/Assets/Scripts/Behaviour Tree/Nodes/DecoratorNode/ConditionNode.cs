using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionNode<T> : DecoratorNode
{
    private Func<T, bool> conditionFunc;
    private string blackboardVar;

    public ConditionNode(ITickable child, Blackboard blackboard, string _blackboardVar, Func<T, bool> func) : base(child, blackboard)
    {
        conditionFunc = func;
        blackboardVar = _blackboardVar;
    }

    public override BTState Tick()
    {
        bool condition = conditionFunc(Blackboard.Get<T>(blackboardVar));

        if (condition == true)
        {
            return BTState.succeeded;
        }

        return BTState.failed;
    }
}

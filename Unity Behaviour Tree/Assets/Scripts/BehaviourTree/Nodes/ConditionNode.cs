using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Composite node that runs all children until all are successfull once

public class ConditionNode<T> : ITickable, IBlackboardable
{
    public Blackboard Blackboard { get; protected set; }

    private RepeatingSequenceNode child1;
    private RepeatingSequenceNode child2;
    private Func<T, bool> conditionFunc;
    private string blackboardVar;

    public ConditionNode(Blackboard blackboard, string blackboardVar, Func<T, bool> func, List<ITickable> child1Tickables, List<ITickable> child2Tickables)
    {
        Blackboard = blackboard;
        this.blackboardVar = blackboardVar;
        conditionFunc = func;
        child1 = new RepeatingSequenceNode(blackboard, child1Tickables);
        child2 = new RepeatingSequenceNode(blackboard, child2Tickables);
    }

    public BTState Tick()
    {
        bool condition = conditionFunc(Blackboard.Get<T>(blackboardVar));

        if (condition == true)
        {
            return child1.Tick();
        }

        return child2.Tick();
    }

    //public List<ITickable> GetChild1() { }
    //public List<ITickable> GetChild2() { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Has a sequence and executes tick

public abstract class CompositeNode : ITickable, ISequenceable, IBlackboardable
{
    public List<ITickable> Tickables { get; private set; } = new List<ITickable>();
    public int TickableIndex { get; private set; } = 0;
    public Blackboard Blackboard { get; private set; }

    public CompositeNode(List<ITickable> tickables, Blackboard blackboard)
    {
        Tickables = tickables;
        Blackboard = blackboard;
    }

    public abstract BTState Tick();

    public void SequenceAdvance()
    {
        if (TickableIndex < Tickables.Count - 1)
        {
            TickableIndex++;
        }
        else
        {
            TickableIndex = 0;
        }
    }

    public ITickable SequenceGetCurrent()
    {
        return Tickables[TickableIndex];
    }

    public void SequenceAdd(ITickable tickable)
    {
        Tickables.Add(tickable);
    }

    public BTState SequenceTick()
    {
        return Tickables[TickableIndex].Tick();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Has a sequence and executes tick

public abstract class CompositeNode : ITickable, ISequenceable, IBlackboardable
{
    public List<ITickable> Tickables { get; protected set; } = new List<ITickable>();
    public int TickableIndex { get; protected set; } = 0;
    public Blackboard Blackboard { get; protected set; }

    public CompositeNode(List<ITickable> tickables, Blackboard blackboard)
    {
        Tickables = tickables;
        Blackboard = blackboard;
    }

    public abstract BTState Tick();

    public virtual void SequenceAdvance()
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

    public void SequenceAdd(ITickable tickable)
    {
        Tickables.Add(tickable);
    }

    public void SequenceAdd(List<ITickable> tickables)
    {
        foreach (ITickable loopTickable in tickables)
        {
            Tickables.Add(loopTickable);
        }
    }

    public BTState SequenceTick()
    {
        ITickable currentTickable = Tickables[TickableIndex];
        Blackboard.Set<ITickable>("CurrentTickable", currentTickable);
        return currentTickable.Tick();
    }
}

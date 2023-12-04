using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The main behaviour tree class that stores the tree (in btTraversables) and the blackboard
public class BT : ITickable, IMultipleTickables<ITickable>, IBlackboardable
{
    public List<ITickable> TickableList { get; set; } = new List<ITickable>();
    public int TickableIndex { get; set; } = 0;
    public Blackboard Blackboard { get; set; } = new Blackboard();

    public BTState Tick()
    {
        if (TickableList.Count == 0) { Debug.LogError("Behaviour Tree Has 0 Branches"); }

        BTState state = TickableList[TickableIndex].Tick();

        if (state == BTState.succeeded)
        {
            if (TickableIndex < TickableList.Count - 1)
            {
                TickableIndex++;
            }
            else
            {
                TickableIndex = 0;
            }
        }

        Blackboard.Set<string>("CurrentBranch", TickableList[TickableIndex].ToString());

        return BTState.succeeded;
    }

    public void Add(ITickable _newTickable)
    {
        if (_newTickable is IBlackboardable)
        {
            IBlackboardable bb = _newTickable as IBlackboardable;
            bb.Blackboard = Blackboard;
        }
        if (_newTickable is IInitiable)
        {
            IInitiable bb = _newTickable as IInitiable;
            bb.Init();
        }

        TickableList.Add(_newTickable);
    }
}
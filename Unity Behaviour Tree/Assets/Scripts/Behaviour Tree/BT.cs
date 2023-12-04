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

        return TickCurrentTickable();
    }

    public BTState TickCurrentTickable()
    {
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
                //Debug.Log("Traversed Entire Tree");
            }
        }

        Blackboard.Set<string>("CurrentBranch", TickableList[TickableIndex].ToString());
        Blackboard.Set<int>("CurrentBranchIndex", TickableIndex);

        return BTState.succeeded;
    }

    public void Add(BaseBranch _newBranch)
    {
        _newBranch.AssignBlackboard(Blackboard);
        _newBranch.Initialize();
        TickableList.Add(_newBranch);
    }

    public void Add(BaseNode _newNode)
    {
        _newNode.AssignBlackboard(Blackboard);
        TickableList.Add(_newNode);
    }
}
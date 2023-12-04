using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The base class for branches (A collection of nodes to perform a action)
public abstract class BaseBranch : ITickable, IMultipleTickables<BaseNode>, IBlackboardable
{
    public List<BaseNode> TickableList { get; set; } = new List<BaseNode>();
    public int TickableIndex { get; set; } = 0;
    public Blackboard Blackboard { get; set; } = new Blackboard();

    public abstract void Initialize();

    public virtual BTState Tick()
    {
        if (TickableList.Count == 0) { Debug.LogError("BTBranch Contains 0 Nodes"); }
        if (Blackboard == null) { Debug.LogError("Blackboard is not assigned"); }

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
                return BTState.succeeded;
            }
        }

        Blackboard.Set<string>("CurrentNode", TickableList[TickableIndex].ToString());
        Blackboard.Set<int>("CurrentNodeIndex", TickableIndex);
        return BTState.running;
    }

    public void AddNode(BaseNode _node)
    {
        _node.AssignBlackboard(Blackboard);
        TickableList.Add(_node);
    }

    public void AssignBlackboard(Blackboard _blackboard)
    {
        Blackboard = _blackboard;
    }
}

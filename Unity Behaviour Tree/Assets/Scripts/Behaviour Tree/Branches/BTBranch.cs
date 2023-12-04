using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTBranch
{
    private List<BTNode> nodes = new List<BTNode>();
    private int nodeIndex = 0;
    protected Blackboard blackboard;

    public abstract void OnEnter();

    public BTState Tick()
    {
        if (nodes.Count == 0) { Debug.LogError("BTBranch Contains 0 Nodes"); }
        if (blackboard == null) { Debug.LogError("Blackboard is not assigned"); }

        return nodes[nodeIndex].Tick();
    }

    public void AddNode(BTNode _node)
    {
        _node.AssignBlackboard(blackboard);
        nodes.Add(_node);
    }

    public void AssignBlackboard(Blackboard _blackboard)
    {
        blackboard = _blackboard;
    }
}

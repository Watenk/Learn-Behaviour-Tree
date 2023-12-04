using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCompositeNode : BaseNode, IMultipleTickables<BaseNode>, IInitiable
{
    public List<BaseNode> TickableList { get; set; } = new List<BaseNode>();
    public int TickableIndex { get; set; } = 0;

    public void AddNode(BaseNode _node)
    {
        _node.Blackboard = Blackboard;
        TickableList.Add(_node);
    }

    public abstract void Init();
}

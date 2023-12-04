using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCompositeNode : BaseNode, IMultipleTickables<BaseNode>
{
    public List<BaseNode> TickableList { get; set; } = new List<BaseNode>();
    public int TickableIndex { get; set; } = 0;

    public override BTState Tick()
    {
        if (TickableList.Count == 0) { Debug.LogError("Composide Node has 0 Children"); }

        return TickCurrentTickable();
    }

    public abstract BTState TickCurrentTickable();
}

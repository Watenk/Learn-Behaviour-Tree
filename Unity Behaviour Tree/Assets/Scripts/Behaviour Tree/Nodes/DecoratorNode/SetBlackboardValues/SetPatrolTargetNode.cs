using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPatrolTargetNode : SetBlackboardValueNode<Vector2>
{
    public SetPatrolTargetNode(ITickable child, Blackboard blackboard, string name, Vector2 value) : base(child, blackboard, name, value)
    {
    }

    public override void UpdateValue()
    {
        if (Blackboard.Get<bool>("TargetReached"))
        {
            Blackboard.Set<bool>("TargetReached", false);
            value = GetRandomPos();
        }
    }

    private Vector2 GetRandomPos()
    {
        Vector2 pos1 = Blackboard.Get<Vector2>("PatrolPos1");
        Vector2 pos2 = Blackboard.Get<Vector2>("PatrolPos2");

        return new Vector2(Random.Range(pos1.x, pos2.x), Random.Range(pos1.y, pos2.y));
    }
}

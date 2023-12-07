using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomTargetNode : SetBlackboardValueNode<Vector2>
{
    public SetRandomTargetNode(Blackboard blackboard) : base(blackboard, "Target", Vector2.zero) { }

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

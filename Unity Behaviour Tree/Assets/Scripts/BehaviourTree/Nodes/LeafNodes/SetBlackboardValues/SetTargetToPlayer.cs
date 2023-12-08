using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetToPlayer : SetBlackboardValueNode<Vector2>
{
    public SetTargetToPlayer(Blackboard blackboard) : base(blackboard, "Target", Vector2.zero) { }

    public override void UpdateValue()
    {
        value = PlayerManager.Instance.gameObject.transform.position;
    }
}

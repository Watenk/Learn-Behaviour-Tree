using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDistanceToPlayerNode : SetBlackboardValueNode<float>
{
    private GameObject body;

    public SetDistanceToPlayerNode(Blackboard blackboard) : base(blackboard, "DistanceToPlayer", 0)
    {
        body = Blackboard.Get<GameObject>("Body");
    }

    public override void UpdateValue()
    {
        value = CalcDistanceToPlayer();
    }

    private float CalcDistanceToPlayer()
    {
        return Vector2.Distance(PlayerManager.Instance.gameObject.transform.position, body.transform.position); 
    }
}

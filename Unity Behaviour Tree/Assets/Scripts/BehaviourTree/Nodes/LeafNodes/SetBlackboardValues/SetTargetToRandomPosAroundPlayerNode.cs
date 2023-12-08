using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetToRandomPosAroundPlayerNode : SetBlackboardValueNode<Vector2>
{
    private GameObject body;

    public SetTargetToRandomPosAroundPlayerNode(Blackboard blackboard) : base(blackboard, "Target", Vector2.zero) 
    {
        body = Blackboard.Get<GameObject>("Body");
    }

    public override void UpdateValue()
    {
        Vector2 playerPos = PlayerManager.Instance.gameObject.transform.position;
        float distance = Blackboard.Get<float>("MaxDistanceFromPlayer");
        value = new Vector2(Random.Range(playerPos.x - distance, playerPos.x + distance), Random.Range(playerPos.y - distance, playerPos.y + distance));
    }
}

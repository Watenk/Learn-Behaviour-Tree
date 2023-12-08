using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ThrowBombToGuardNode : LeafNode
{
    private GameObject body;

    public ThrowBombToGuardNode(Blackboard blackboard) : base(blackboard) 
    {
        body = Blackboard.Get<GameObject>("Body");
    }

    public override BTState Tick()
    {
        base.Tick();

        Vector2 bodyPos = body.transform.position;
        Vector2 dir = bodyPos - GuardManager.Instance.GetGuardPos();
        dir.Normalize();
        BombManager.Instance.ThrowBomb(bodyPos, dir);

        return BTState.succeeded;
    }
}

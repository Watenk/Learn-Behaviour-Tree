using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAttackParticleNode : LeafNode
{
    private GameObject body;

    public PlayAttackParticleNode(Blackboard blackboard) : base(blackboard) 
    {
        body = Blackboard.Get<GameObject>("Body");
    }

    public override BTState Tick()
    {
        base.Tick();

        ParticleManager.Instance.PlayAttackParticle(body.transform.position);

        return BTState.succeeded;
    }
}

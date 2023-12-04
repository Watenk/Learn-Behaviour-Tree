using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitParticleNode : BaseNode
{
    public override BTState Tick()
    {
        Vector3 pos = Blackboard.Get<GameObject>("Body").transform.position;
        GameObject particlePrefab = Blackboard.Get<GameObject>("Particle");
        TestAI testAI = Blackboard.Get<TestAI>("TestAI");

        testAI.InstantiateObject(particlePrefab, new Vector2(pos.x, pos.y));

        return BTState.succeeded;
    }
}

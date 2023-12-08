using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosNode : LeafNode
{
    private Rigidbody2D rb;
    private GameObject body;

    public MoveToPosNode(Blackboard blackboard) : base(blackboard)
    {
        rb = Blackboard.Get<Rigidbody2D>("Rigidbody2D");
        body = Blackboard.Get<GameObject>("Body");
    }

    public override BTState Tick()
    {
        base.Tick();

        Vector2 target = Blackboard.Get<Vector2>("Target");
        float speed = Blackboard.Get<float>("Speed");

        Vector2 dir = (Vector2)body.transform.position - target;
        dir.Normalize();
        rb.MovePosition(body.transform.position - new Vector3(dir.x, dir.y, 0) * speed * Time.deltaTime);

        if (Vector2.Distance(body.transform.position, target) < 0.5)
        {
            Blackboard.Set<bool>("TargetReached", true);
            return BTState.succeeded;
        }

        return BTState.running;
    }
}

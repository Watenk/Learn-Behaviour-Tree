using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Moves the player towards a target using RB2D
public class WalkToPosNode : BaseNode
{
    private Vector2 target;

    public override BTState Tick()
    {
        base.Tick();

        //Blackboard
        GameObject body = Blackboard.Get<GameObject>("Body");
        Rigidbody2D rb = Blackboard.Get<Rigidbody2D>("RB2D");
        float speed = Blackboard.Get<float>("Speed");

        Vector2 bodyVector2 = new Vector2(body.transform.position.x, body.transform.position.y);

        if (Vector2.Distance(bodyVector2, target) < 0.1f)
        {
            return BTState.succeeded;
        }

        Vector2 dir = bodyVector2 - target;
        dir.Normalize();
        rb.MovePosition(body.transform.position - new Vector3(dir.x, dir.y, 0) * speed * Time.deltaTime);

        return BTState.running;
    }

    public void SetTarget(Vector2 _target)
    {
        target = _target;
    }
}

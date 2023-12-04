using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToPos : BTNode
{
    public override BTState Tick()
    {
        //Blackboard
        GameObject body = blackboard.Get<GameObject>("Body");
        Rigidbody2D rb = blackboard.Get<Rigidbody2D>("RB2D");
        float speed = blackboard.Get<float>("Speed");
        Vector2 target = blackboard.Get<Vector2>("WalkToPosTarget");

        Vector2 bodyVector2 = new Vector2(body.transform.position.x, body.transform.position.y);

        if (Vector2.Distance(bodyVector2, target) < 0.5f)
        {
            return BTState.succeeded;
        }

        Vector2 dir = bodyVector2 - target;
        dir.Normalize();
        rb.MovePosition(body.transform.position - new Vector3(dir.x, dir.y, 0) * speed * Time.deltaTime);

        return BTState.running;
    }
}

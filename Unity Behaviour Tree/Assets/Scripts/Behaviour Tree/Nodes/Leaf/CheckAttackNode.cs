using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttackNode : BaseNode
{
    private GameObject body;
    private int attackDistance;

    public void Start()
    {
        body = Blackboard.Get<GameObject>("Body");
    }

    public override BTState Tick()
    {
        base.Tick();

        if (Vector2.Distance(
            new Vector2(body.transform.position.x, body.transform.position.y), 
            new Vector2(PlayerController.Instance.transform.position.x, PlayerController.Instance.transform.position.y))
            < attackDistance)
        {
            return BTState.succeeded;
        }

        return BTState.failed;
    }

    public void SetAttackDistance(int _distance)
    {
        attackDistance = _distance;
    }
}

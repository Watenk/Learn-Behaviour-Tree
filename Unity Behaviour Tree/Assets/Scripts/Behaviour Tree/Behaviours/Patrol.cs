using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : LoopCompositeNode
{
    private WalkToPosNode walkToPos = new WalkToPosNode();
    private Vector2 Pos1;
    private Vector2 Pos2;

    public override void Init()
    {
        walkToPos.SetTarget(new Vector2(Random.Range(Pos1.x, Pos2.x), Random.Range(Pos1.y, Pos2.y)));
        AddNode(walkToPos);
    }

    public override BTState Tick()
    {
        BTState state = base.Tick();

        if (state == BTState.succeeded)
        {
            walkToPos.SetTarget(new Vector2(Random.Range(Pos1.x, Pos2.x), Random.Range(Pos1.y, Pos2.y)));
        }

        return BTState.running;
    }

    public void SetArea(Vector2 _pos1, Vector2 _pos2)
    {
        Pos1 = _pos1;
        Pos2 = _pos2;
    }
}

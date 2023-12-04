using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : BTBranch
{
    public override void OnEnter()
    {
        blackboard.Set<Vector2>("WalkToPosTarget", Camera.main.ScreenToWorldPoint(Input.mousePosition));
        AddNode(new WalkToPos());
    }
}

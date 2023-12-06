using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBlackboard : Blackboard
{
    public AIBlackboard()
    {
        // Types
        AddType<Rigidbody2D>();
        AddType<GameObject>();
        AddType<Vector2>();
        AddType<float>();
        AddType<bool>();

        // References
        Add<Rigidbody2D>("Rigidbody2D");
        Add<GameObject>("Body");

        // Values
        Add<Vector2>("Target");
        Add<Vector2>("PatrolPos1");
        Add<Vector2>("PatrolPos2");
        Add<float>("Speed");
        Add<bool>("TargetReached", false);
    }
}

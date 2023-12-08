using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAIBlackboard : Blackboard
{
    public NinjaAIBlackboard()
    {
        // Types
        AddType<Rigidbody2D>();
        AddType<GameObject>();
        AddType<ITickable>();
        AddType<Vector2>();
        AddType<float>();
        AddType<bool>();

        // References
        Add<Rigidbody2D>("Rigidbody2D");
        Add<GameObject>("Body");

        // Values
        Add<ITickable>("CurrentTickable");
        Add<Vector2>("Target");
        Add<float>("Speed");
        Add<float>("DetectDistance");
        Add<float>("AttackDistance");
        Add<float>("PatrolWaitAmount");
        Add<float>("AttackCooldown");
        Add<float>("DistanceToGuard");
        Add<float>("MaxDistanceFromPlayer");
        Add<bool>("TargetReached", false);
        Add<bool>("Attacking", false);
    }
}

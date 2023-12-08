using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAIBlackboard : Blackboard
{
    public GuardAIBlackboard()
    {
        // Types
        AddType<Rigidbody2D>();
        AddType<GameObject>();
        AddType<ITickable>();
        AddType<IWeapon>();
        AddType<Vector2>();
        AddType<float>();
        AddType<bool>();

        // References
        Add<Rigidbody2D>("Rigidbody2D");
        Add<GameObject>("Body");

        // Values
        Add<ITickable>("CurrentTickable");
        Add<IWeapon>("EquipedWeapon", null);
        Add<IWeapon>("PendingWeapon", null);
        Add<Vector2>("Target");
        Add<Vector2>("PatrolPos1");
        Add<Vector2>("PatrolPos2");
        Add<float>("Speed");
        Add<float>("DetectDistance");
        Add<float>("AttackDistance");
        Add<float>("PatrolWaitAmount");
        Add<float>("AttackCooldown");
        Add<float>("DistanceToPlayer");
        Add<bool>("TargetReached", false);
        Add<bool>("Attacking", false);
        Add<bool>("Stunned", false);
    }
}

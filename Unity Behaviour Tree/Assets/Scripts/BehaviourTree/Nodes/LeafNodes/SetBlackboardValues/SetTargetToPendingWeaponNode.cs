using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetToPendingWeaponNode : SetBlackboardValueNode<Vector2>
{
    public SetTargetToPendingWeaponNode(Blackboard blackboard) : base(blackboard, "Target", Vector2.zero) { }

    public override void UpdateValue()
    {
        value = Blackboard.Get<IWeapon>("PendingWeapon").GetPos();
    }
}

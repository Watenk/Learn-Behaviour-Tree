using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetToClosestWeaponNode : SetBlackboardValueNode<Vector2>
{
    private GameObject body;

    public SetTargetToClosestWeaponNode(Blackboard blackboard) : base(blackboard, "Target", Vector2.zero) 
    {
        body = Blackboard.Get<GameObject>("Body");
    }

    public override void UpdateValue()
    {
        Blackboard.Set<bool>("Attacking", true);

        if (Blackboard.Get<IWeapon>("PendingWeapon") == null)
        {
            IWeapon pendingWeapon = WeaponManager.Instance.GetClosestUnquippedWeapon(body.transform.position);
            Blackboard.Set<IWeapon>("PendingWeapon", pendingWeapon);
            value = pendingWeapon.GetPos();
        }

        value = Blackboard.Get<IWeapon>("PendingWeapon").GetPos();
    }
}

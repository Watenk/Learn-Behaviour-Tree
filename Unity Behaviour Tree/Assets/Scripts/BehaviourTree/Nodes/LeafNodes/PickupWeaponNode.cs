using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeaponNode : LeafNode
{
    private GameObject body;

    public PickupWeaponNode(Blackboard blackboard) : base(blackboard) 
    {
        body = Blackboard.Get<GameObject>("Body");
    }

    public override BTState Tick()
    {
        base.Tick();

        IWeapon pendingWeapon = Blackboard.Get<IWeapon>("PendingWeapon");

        if (Vector2.Distance(pendingWeapon.GetPos(), body.transform.position) < 0.1)
        {
            IWeapon equipedWeapon = WeaponManager.Instance.EquipWeapon(pendingWeapon);
            equipedWeapon.SetWielder(body);
            Blackboard.Set<IWeapon>("PendingWeapon", null);
            Blackboard.Set<IWeapon>("EquipedWeapon", equipedWeapon);
        }

        return BTState.succeeded;
    }
}

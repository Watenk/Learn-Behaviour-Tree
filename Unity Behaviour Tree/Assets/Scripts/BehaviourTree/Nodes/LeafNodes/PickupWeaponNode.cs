using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeaponNode : LeafNode
{
    public PickupWeaponNode(Blackboard blackboard) : base(blackboard) { }

    public override BTState Tick()
    {
        base.Tick();

        IWeapon equipedWeapon = WeaponManager.Instance.EquipWeapon(Blackboard.Get<IWeapon>("PendingWeapon"));
        Blackboard.Set<IWeapon>("PendingWeapon", null);
        Blackboard.Set<IWeapon>("EquipedWeapon", equipedWeapon);

        return BTState.succeeded;
    }
}

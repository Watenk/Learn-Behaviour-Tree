using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeaponNode : BaseNode
{
    private IWeapon targetWeapon = null;
    private GameObject body;

    public void Start()
    {
        body = Blackboard.Get<GameObject>("Body");
    }

    public override BTState Tick()
    {
        if (targetWeapon == null)
        {
            Blackboard.Set<IWeapon>("Weapon", WeaponManager.Instance.GetClosestUnquippedWeapon(new Vector2(body.transform.position.x, body.transform.position.y));

            if (targetWeapon == null) { return BTState.running; }
            return BTState.succeeded;
        }
        else
        {
            return BTState.succeeded;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : SequenceCompositeNode
{
    private GetWeaponNode getWeaponNode = new GetWeaponNode();
    private WalkToPosNode walkToWeapon = new WalkToPosNode();   
    private WalkToPosNode walkToPlayer = new WalkToPosNode();

    public override void Init()
    {
        AddNode(getWeaponNode);
        walkToWeapon.SetTarget(Blackboard.Get<IWeapon>("Weapon").GetPos());
        AddNode(walkToWeapon);
        walkToPlayer.SetTarget(Blackboard.Get<GameObject>("Body").transform.position);
        AddNode(walkToPlayer);
    }
}

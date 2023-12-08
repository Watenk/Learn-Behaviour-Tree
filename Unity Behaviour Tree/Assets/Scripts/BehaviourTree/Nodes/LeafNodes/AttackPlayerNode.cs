using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNode : LeafNode
{
    private IDamagable damagable;

    public AttackNode(Blackboard blackboard, IDamagable damagable) : base(blackboard) 
    {
        this.damagable = damagable;
    }

    public override BTState Tick()
    {
        base.Tick();

        damagable.TakeDamage(1);
        PlayerManager.Instance.IsAttacked = true;

        return BTState.succeeded;
    }
}

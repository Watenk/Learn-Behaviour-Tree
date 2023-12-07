using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequences
{
    // Level 1 Sequences
    public List<ITickable> AttackAndPatrolSequence(Blackboard bb)
    {
        Func<float, bool> isDistanceLessThan = (currentDistance) => currentDistance < 10;

        List<ITickable> attackAndPatrolSequence = new List<ITickable>
        {
            new SingleSequenceNode(bb, new List<ITickable>
            {
                new SetDistanceToPlayerNode(bb),
                new ConditionNode<float>(bb, "DistanceToPlayer", isDistanceLessThan,
                    AttackSequence(bb),
                    PatrolSequence(bb)
                )
            }
            )
        };

        return attackAndPatrolSequence;
    }

    // Level 2 sequences
    ///////////////////////////////////////////////////////

    public List<ITickable> AttackSequence(Blackboard bb)
    {
        Func<IWeapon, bool> isWeaponEquiped = (weapon) => weapon != null;

        List<ITickable> attackSequence = new List<ITickable>
        {
            new ConditionNode<IWeapon>(bb, "EquipedWeapon", isWeaponEquiped, 
                AttackPlayer(bb),
                GetWeapon(bb)
            )
        };

        return attackSequence;
    }

    public List<ITickable> PatrolSequence(Blackboard bb)
    {
        List<ITickable> patrolSequence = new List<ITickable>
        {
            new SetRandomTargetNode(bb),
            new MoveToPosNode(bb),
            new WaitNode(bb, 5)
        };

        return patrolSequence;
    }

    // Level 3 sequences
    /////////////////////////////////////////////////////////////////

    public List<ITickable> AttackPlayer(Blackboard bb)
    {
        List<ITickable> attackPlayerSequence = new List<ITickable>
        {
            new SetBlackboardValueNode<Vector2>(bb, "Target", PlayerManager.Instance.transform.position),
            new MoveToPosNode(bb)
        };

        return attackPlayerSequence;
    }

    public List<ITickable> GetWeapon(Blackboard bb)
    {
        List<ITickable> getWeaponSequence = new List<ITickable>
        {
            new SetTargetToClosestWeaponNode(bb),
            new MoveToPosNode(bb),
            new PickupWeaponNode(bb)
        };

        return getWeaponSequence;
    }
}

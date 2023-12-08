using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is totally unreadable...
// Contains all the sequences

public class Sequences
{
    // Level 1 Sequences (The main sequences)
    public List<ITickable> AttackAndPatrol(Blackboard bb)
    {
        Func<bool, bool> isStunned = (stunned) => stunned;

        List<ITickable> sequence = new List<ITickable>
        {
            new RepeatingSequenceNode(bb, new List<ITickable>
            {
                new SetDistanceToPlayerNode(bb),
                new ConditionNode<bool>(bb, "Stunned", isStunned,
                    BeStunned(bb),
                    CheckDistanceToPlayer(bb)
                )
            })
        };

        return sequence;
    }

    public List<ITickable> GuardAndStealthAttack(Blackboard bb)
    {
        Func<Vector2, bool> agentAttackCondition = (playerIsAttacked) => PlayerManager.Instance.IsAttacked;

        List<ITickable> sequence = new List<ITickable>
        {
            new RepeatingSequenceNode(bb, new List<ITickable>
            {
                new ConditionNode<Vector2>(bb, "Target", agentAttackCondition,
                    StealthAttackSequence(bb),
                    GuardPlayer(bb)
                )
            })
        };

        return sequence;
    }

    // Level 2 sequences (A sequence in a sequence using a ConditionNode)
    ///////////////////////////////////////////////////////
    ///
    public List<ITickable> StealthAttackSequence(Blackboard bb)
    {
        Func<GameObject, bool> isAgentAtTree = (body) => Vector2.Distance(body.transform.position, new Vector2(5, 15)) < 0.5;

        List<ITickable> sequence = new List<ITickable>
        {
            new RepeatingSequenceNode(bb, new List<ITickable>
            {
                new ConditionNode<GameObject>(bb, "Body", isAgentAtTree,
                    ThrowBombAtGuard(bb),
                    GoToTree(bb)
                )
            })
        };

        return sequence;
    }

    public List<ITickable> IsWeaponEquipped(Blackboard bb)
    {
        Func<IWeapon, bool> isWeaponEquiped = (weapon) => weapon != null;

        List<ITickable> Sequence = new List<ITickable>
        {
            new RepeatingSequenceNode(bb, new List<ITickable>
            {
                new ConditionNode<IWeapon>(bb, "EquipedWeapon", isWeaponEquiped, 
                    AttackPlayer(bb),
                    GetWeapon(bb)
                )
            })
        };

        return Sequence;
    }

    public List<ITickable> GetWeapon(Blackboard bb)
    {
        Func<IWeapon, bool> isThereAPendingWeapon = (pendingWeapon) => pendingWeapon != null;

        List<ITickable> sequence = new List<ITickable>
        {
            new RepeatingSequenceNode(bb, new List<ITickable>
            {
                new ConditionNode<IWeapon>(bb, "PendingWeapon", isThereAPendingWeapon,
                    GetPendingWeapon(bb),
                    SearchForWeapon(bb)
                )
            })
        };

        return sequence;
    }

    public List<ITickable> AttackPlayer(Blackboard bb)
    {
        Func<GameObject, bool> canAgentReachPlayer = (agent) => 
            Vector2.Distance(agent.transform.position, PlayerManager.Instance.gameObject.transform.position) < bb.Get<float>("AttackDistance");

        List<ITickable> sequence = new List<ITickable>
        {
            new SequenceNode(bb, new List<ITickable>
            {
                new ConditionNode<GameObject>(bb, "Body", canAgentReachPlayer, 
                    HitPlayer(bb),
                    MoveToPlayer(bb)
                )
            }),
        };

        return sequence;
    }

    public List<ITickable> CheckDistanceToPlayer(Blackboard bb)
    {
        Func<float, bool> agentAttackCondition = (currentDistance) =>
            currentDistance < bb.Get<float>("DetectDistance") || bb.Get<bool>("Attacking");

        List<ITickable> sequence = new List<ITickable>
        {
            new ConditionNode<float>(bb, "DistanceToPlayer", agentAttackCondition,
                IsWeaponEquipped(bb),
                PatrolSequence(bb)
            )
        };

        return sequence;
    }


    // Level 3 sequences (A sequence in a sequence)
    /////////////////////////////////////////////////////////////////

    public List<ITickable> PatrolSequence(Blackboard bb)
    {
        List<ITickable> sequence = new List<ITickable>
        {
            new RepeatingSequenceNode(bb, new List<ITickable>
            {
                new SetRandomTargetNode(bb),
                new MoveToPosNode(bb),
                new WaitNode(bb, bb.Get<float>("PatrolWaitAmount"))
            })
        };

        return sequence;
    }

    public List<ITickable> HitPlayer(Blackboard bb)
    {
        List<ITickable> sequence = new List<ITickable>
        {
            new SequenceNode(bb, new List<ITickable>
            {
                new AttackNode(bb, PlayerManager.Instance.GetComponent<IDamagable>()),
                new PlayAttackParticleNode(bb),
                new WaitNode(bb, bb.Get<float>("AttackCooldown"))
            })
        };

        return sequence;
    }

    public List<ITickable> GuardPlayer(Blackboard bb)
    {
        List<ITickable> sequence = new List<ITickable>
        {
            new SequenceNode(bb, new List<ITickable>
            {
                new SetTargetToRandomPosAroundPlayerNode(bb),
                new MoveToPosNode(bb)
            })
        };

        return sequence;
    }

    public List<ITickable> GoToTree(Blackboard bb)
    {
        List<ITickable> sequence = new List<ITickable>
        {
            new SequenceNode(bb, new List<ITickable>
            {
                new SetBlackboardValueNode<Vector2>(bb, "Target", new Vector2(5, 15)),
                new MoveToPosNode(bb),
                new SetBlackboardValueNode<bool>(bb, "TargetReached", true)
            })
        };

        return sequence;
    }

    // Level 4 sequences (A sequence)
    //////////////////////////////////////////////////////////

    public List<ITickable> GetPendingWeapon(Blackboard bb)
    {
        List<ITickable> sequence = new List<ITickable>
        {
            new SetTargetToPendingWeaponNode(bb),
            new MoveToPosNode(bb),
            new PickupWeaponNode(bb)
        };

        return sequence;
    }

    public List<ITickable> SearchForWeapon(Blackboard bb)
    {
        List<ITickable> sequence = new List<ITickable>
        {
            new SetTargetToClosestWeaponNode(bb),
        };

        return sequence;
    }

    public List<ITickable> MoveToPlayer(Blackboard bb)
    {
        List<ITickable> sequence = new List<ITickable>
        {
            new SetTargetToPlayer(bb),
            new MoveToPosNode(bb),
        };

        return sequence;
    }

    public List<ITickable> ThrowBombAtGuard(Blackboard bb)
    {
        List<ITickable> sequence = new List<ITickable>
        {
            new WaitNode(bb, bb.Get<float>("AttackCooldown")),
            new ThrowBombToGuardNode(bb)
        };

        return sequence;
    }

    public List<ITickable> BeStunned(Blackboard bb)
    {
        List<ITickable> sequence = new List<ITickable>
        {
            new StunnedNode(bb, 3)
        };

        return sequence;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardAI : MonoBehaviour, IDamagable
{
    public Text CurrentNodeText;
    public int Health { get; private set; } = 3;
    public int MaxHealth { get; private set; } = 3;

    public GuardAIBlackboard bb;
    private BehaviourTree bt;


    public void Start()
    {
        GuardManager.Instance.AddGuard(this);

        // Set Blackboard Values
        bb = new GuardAIBlackboard();
        bb.Set<Rigidbody2D>("Rigidbody2D", GetComponent<Rigidbody2D>());
        bb.Set<GameObject>("Body", this.gameObject);
        bb.Set<float>("Speed", 10);
        bb.Set<Vector2>("PatrolPos1", new Vector2(-20, -20));
        bb.Set<Vector2>("PatrolPos2", new Vector2(20, 20));
        bb.Set<float>("DetectDistance", 10);
        bb.Set<float>("AttackDistance", 5);
        bb.Set<float>("PatrolWaitAmount", 5);
        bb.Set<float>("AttackCooldown", 2);

        bt = new BehaviourTree(bb);

        // Build Tree
        Sequences sequences = new Sequences();
        bt.SequenceAdd(sequences.AttackAndPatrol(bb)); 
    }

    public void FixedUpdate()
    {
        bt.Tick();

        // Debug
        CurrentNodeText.text = bt.Blackboard.Get<ITickable>("CurrentTickable").ToString();
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GuardManager.Instance.RemoveGuard(this);
        Destroy(gameObject);
    }
}

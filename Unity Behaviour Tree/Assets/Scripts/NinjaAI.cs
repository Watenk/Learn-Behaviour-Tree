using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaAI : MonoBehaviour
{
    public Text CurrentNodeText;

    private NinjaAIBlackboard bb;
    private BehaviourTree bt;

    public void Start()
    {
        // Set Blackboard Values
        bb = new NinjaAIBlackboard();
        bb.Set<Rigidbody2D>("Rigidbody2D", GetComponent<Rigidbody2D>());
        bb.Set<GameObject>("Body", this.gameObject);
        bb.Set<float>("Speed", 10);
        bb.Set<float>("DetectDistance", 10);
        bb.Set<float>("AttackDistance", 5);
        bb.Set<float>("PatrolWaitAmount", 5);
        bb.Set<float>("AttackCooldown", 5);
        bb.Set<float>("MaxDistanceFromPlayer", 5);

        bt = new BehaviourTree(bb);

        // Build Tree
        Sequences sequences = new Sequences();
        bt.SequenceAdd(sequences.GuardAndStealthAttack(bb));
    }

    public void FixedUpdate()
    {
        bt.Tick();

        // Debug
        CurrentNodeText.text = bt.Blackboard.Get<ITickable>("CurrentTickable").ToString();
    }
}

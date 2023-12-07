using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardAI : MonoBehaviour
{
    public Text CurrentNodeText;

    private AIBlackboard bb;
    private BehaviourTree bt;


    private void Start()
    {
        // Blackboard
        bb = new AIBlackboard();
        bb.Set<Rigidbody2D>("Rigidbody2D", GetComponent<Rigidbody2D>());
        bb.Set<GameObject>("Body", this.gameObject);
        bb.Set<float>("Speed", 10);
        bb.Set<Vector2>("PatrolPos1", new Vector2(-20, -20));
        bb.Set<Vector2>("PatrolPos2", new Vector2(20, 20));

        bt = new BehaviourTree(bb);

        // Build Tree
        Sequences sequences = new Sequences();
        bt.SequenceAdd(sequences.AttackAndPatrolSequence(bb));
    }

    public void FixedUpdate()
    {
        bt.Tick();

        // Debug
        CurrentNodeText.text = bt.Blackboard.Get<ITickable>("CurrentTickable").ToString();
    }
}

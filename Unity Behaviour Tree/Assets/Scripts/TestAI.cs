using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    BT bt = new BT();

    void Start()
    {
        //Blackboard
        bt.blackboard.AddType<Rigidbody2D>();
        bt.blackboard.AddType<GameObject>();
        bt.blackboard.AddType<Vector2>();
        bt.blackboard.AddType<float>();

        bt.blackboard.Add<Rigidbody2D>("RB2D", GetComponent<Rigidbody2D>());
        bt.blackboard.Add<GameObject>("Body", gameObject);
        bt.blackboard.Add<Vector2>("WalkToPosTarget");
        bt.blackboard.Add<float>("Speed", 10);

        //Branches
        bt.AddBranch(new MoveToMouse());
    }

    void FixedUpdate()
    {
        bt.Tick();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardAI : MonoBehaviour
{
    public Text CurrentNodeText;

    private AIBlackboard bb = new AIBlackboard();
    private List<ITickable> mainTreeSequence;
    private BehaviourTree bt;


    private void Start()
    {
        // Blackboard
        bb.Set<Rigidbody2D>("Rigidbody2D", GetComponent<Rigidbody2D>());
        bb.Set<GameObject>("Body", this.gameObject);
        bb.Set<float>("Speed", 10);
        bb.Set<Vector2>("PatrolPos1", new Vector2(-20, -20));
        bb.Set<Vector2>("PatrolPos2", new Vector2(20, 20));

        // Main Sequence
        mainTreeSequence = new List<ITickable>
        {
            new SetPatrolTargetNode(
                new MoveToPosNode(bb),
                bb, "Target", Vector2.zero),

            new WaitNode(bb, 5)
        };

        bt = new BehaviourTree(mainTreeSequence ,bb);
    }

    public void FixedUpdate()
    {
        bt.Tick();

        DebugText();
    }

    private void DebugText()
    {
        ITickable currentTickable = bt.SequenceGetCurrent();
        if (currentTickable is DecoratorNode)
        {
            DecoratorNode currentDecorator = (DecoratorNode)currentTickable;
            CurrentNodeText.text = currentDecorator.GetChild().ToString();
        }
        else if (currentTickable is CompositeNode)
        {
            CompositeNode currentComposite = (CompositeNode)currentTickable;
            CurrentNodeText.text = currentComposite.SequenceGetCurrent().ToString();
        }
        else // Leaf Node
        {
            CurrentNodeText.text = currentTickable.ToString();

        }
    }
}

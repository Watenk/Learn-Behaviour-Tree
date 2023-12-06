using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : RepeatorNode
{
    public BehaviourTree(List<ITickable> tickables, Blackboard blackboard) : base(tickables, blackboard) { }
}

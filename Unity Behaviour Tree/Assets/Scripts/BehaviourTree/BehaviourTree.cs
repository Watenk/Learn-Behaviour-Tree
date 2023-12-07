using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : RootNode
{
    public BehaviourTree(Blackboard blackboard) : base(new List<ITickable>(), blackboard) { }
}

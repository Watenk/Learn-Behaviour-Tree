using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT
{
    public Blackboard blackboard = new Blackboard();
    private List<BTBranch> btBranches = new List<BTBranch>();
    private int branchIndex = 0;

    public void Tick()
    {
        if (btBranches.Count == 0) { Debug.LogError("Behaviour Tree Has 0 Branches"); }

        btBranches[branchIndex].Tick();
    }

    public void AddBranch(BTBranch _newBranch)
    {
        _newBranch.AssignBlackboard(blackboard);
        _newBranch.OnEnter();
        btBranches.Add(_newBranch);
    }
}
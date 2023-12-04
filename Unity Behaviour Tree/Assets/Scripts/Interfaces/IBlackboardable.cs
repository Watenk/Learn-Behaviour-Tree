using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlackboardable
{
    Blackboard Blackboard { get; set; }
}

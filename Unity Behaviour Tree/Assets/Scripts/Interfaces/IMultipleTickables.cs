using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMultipleTickables<T>
{
    List<T> TickableList { get; set; }
    int TickableIndex { get; set; }

    BTState TickCurrentTickable();
}
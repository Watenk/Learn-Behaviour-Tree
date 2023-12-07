using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISequenceable
{
    List<ITickable> Tickables { get; }
    int TickableIndex { get; }

    BTState SequenceTick();
    void SequenceAdvance();
    void SequenceAdd(ITickable tickable);
}
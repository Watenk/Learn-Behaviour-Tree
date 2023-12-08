using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardManager : MonoBehaviour
{
    public static GuardManager Instance { get; private set; }

    private List<GuardAI> guards = new List<GuardAI>();

    public void Awake()
    {
        Instance = this;
    }

    public void AddGuard(GuardAI newGuard)
    {
        guards.Add(newGuard);
    }

    public void RemoveGuard(GuardAI newGuard)
    {
        guards.Remove(newGuard);
    }

    public Vector2 GetGuardPos()
    {
        if (guards.Count != 0)
        {
            return guards[0].gameObject.transform.position;
        }

        return Vector2.zero;
    }

    public void StunGuard()
    {
        guards[0].bb.Set<bool>("Stunned", true);
        guards[0].TakeDamage(1);
    }
}

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

    public Vector2 GetGuardPos()
    {
        return guards[0].gameObject.transform.position;
    }
}

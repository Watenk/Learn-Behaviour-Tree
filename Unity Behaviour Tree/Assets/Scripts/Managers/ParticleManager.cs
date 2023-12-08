using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance { get; private set; }

    public GameObject AttackParticle;
    public GameObject ExplodeParticle;

    public void Awake()
    {
        Instance = this;
    }

    public void PlayAttackParticle(Vector2 pos)
    {
        Instantiate(AttackParticle, new Vector3(pos.x, pos.y, -5), Quaternion.identity);
    }

    public void PlayExplodeParticle(Vector2 pos)
    {
        Instantiate(ExplodeParticle, new Vector3(pos.x, pos.y, -5), Quaternion.identity);
    }
}

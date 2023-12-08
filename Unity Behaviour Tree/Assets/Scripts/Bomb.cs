using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Vector2 Dir;
    public float Speed;
    public float ExplodeTime;
    public float ExplosionRange;

    private Rigidbody2D rb;
    private float timer;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = ExplodeTime;
    }

    public void FixedUpdate()
    {
        rb.MovePosition(transform.position - new Vector3(Dir.x, Dir.y, 0) * Speed * Time.deltaTime);

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        ParticleManager.Instance.PlayExplodeParticle(gameObject.transform.position);
        Vector2 guardPos = GuardManager.Instance.GetGuardPos();

        if (Vector2.Distance(guardPos, gameObject.transform.position) <= ExplosionRange)
        {
            GuardManager.Instance.StunGuard();
        }

        Destroy(gameObject);
    }
}

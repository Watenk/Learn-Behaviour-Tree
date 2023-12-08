using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Vector2 Dir;
    public float Speed;
    public float ExplodeTime;

    private Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    public void FixedUpdate()
    {
        rb.MovePosition(transform.position - new Vector3(Dir.x, Dir.y, 0) * Speed * Time.deltaTime);
    }
}

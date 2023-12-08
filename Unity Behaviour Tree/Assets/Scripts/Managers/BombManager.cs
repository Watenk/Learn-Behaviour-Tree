using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public static BombManager Instance { get; private set; }

    public GameObject BombPrefab;

    public void Awake()
    {
        Instance = this;
    }

    public void ThrowBomb(Vector2 orgin, Vector2 dir)
    {
        Bomb bomb = Instantiate(BombPrefab, orgin, Quaternion.identity).GetComponent<Bomb>();
        bomb.Dir = dir;
    }
}

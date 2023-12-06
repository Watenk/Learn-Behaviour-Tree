using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knive : MonoBehaviour, IWeapon
{
    public bool IsEquipped { get; set; } = false;

    public void Start()
    {
        WeaponManager.Instance.AddWeapon(this);
    }

    public Vector2 GetPos()
    {
        return gameObject.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knive : MonoBehaviour, IWeapon
{
    public GameObject wielder { get; private set; } = null;

    public void Start()
    {
        WeaponManager.Instance.AddWeapon(this);
    }

    public Vector2 GetPos()
    {
        return gameObject.transform.position;
    }

    public void SetWielder(GameObject _wielder)
    {
        wielder = _wielder;
        transform.SetParent(_wielder.transform);
    }
}

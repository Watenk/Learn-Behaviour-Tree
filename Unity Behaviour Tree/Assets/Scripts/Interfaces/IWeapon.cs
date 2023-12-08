using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    GameObject wielder { get; }

    Vector2 GetPos();
    void SetWielder(GameObject wielder);
}

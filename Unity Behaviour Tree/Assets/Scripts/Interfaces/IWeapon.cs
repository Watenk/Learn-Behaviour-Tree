using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    bool IsEquipped { get; set; }

    Vector2 GetPos();
}

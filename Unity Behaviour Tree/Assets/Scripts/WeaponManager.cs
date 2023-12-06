using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }

    private List<IWeapon> unequippedWeapons = new List<IWeapon>();
    private List<IWeapon> pendingWeapons = new List<IWeapon>();
    private List<IWeapon> equippedWeapons = new List<IWeapon>();

    public void Awake()
    {
        Instance = this;
    }

    public IWeapon GetClosestUnquippedWeapon(Vector2 pos)
    {
        IWeapon closestWeapon;

        if (unequippedWeapons.Count > 0)
        {
            closestWeapon = unequippedWeapons[0];

            foreach (var loopWeapon in unequippedWeapons)
            {
                if (Vector2.Distance(pos, loopWeapon.GetPos()) < Vector2.Distance(pos, closestWeapon.GetPos()))
                {
                    closestWeapon = loopWeapon;
                }
            }

            unequippedWeapons.Remove(closestWeapon);
            pendingWeapons.Add(closestWeapon);
            return closestWeapon;
        }
        else { return null; }
    }

    public void ReleasePendingWeapon(IWeapon weapon)
    {
        pendingWeapons.Remove(weapon);
        unequippedWeapons.Add(weapon);
    }

    public void EquipWeapon(IWeapon weapon)
    {
        pendingWeapons.Remove(weapon);
        equippedWeapons.Add(weapon);
    }

    public void AddWeapon(IWeapon newWeapon)
    {
        unequippedWeapons.Add(newWeapon);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{ 
    int Health { get; }
    int MaxHealth { get; }

    void TakeDamage(int amount);
    void Die();
}

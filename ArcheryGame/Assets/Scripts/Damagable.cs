using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    ArrowDamageResponse TakeArrowDamage(float damageAmount);
    void TakeDamage(float damageAmount);
}

public interface IEffectedDamagable : IDamagable
{
}


public enum ArrowDamageResponse
{
    None, 
    Destroy,
    Stuck,
    Reflect
}
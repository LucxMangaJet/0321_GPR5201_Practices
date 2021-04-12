using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDamage : MonoBehaviour, IEffectedDamagable
{
    public ArrowDamageResponse TakeDamage(float damageAmount)
    {
        Debug.Log(name + " took " + damageAmount + " damage.");
        Destroy(gameObject);
        return ArrowDamageResponse.Destroy;
    }

    public bool IgnoresEffect(string effectName)
    {
        return false;
    }

    public ArrowDamageResponse TakeArrowDamage(float damageAmount)
    {
        throw new System.NotImplementedException();
    }

    void IDamagable.TakeDamage(float damageAmount)
    {
        throw new System.NotImplementedException();
    }
}

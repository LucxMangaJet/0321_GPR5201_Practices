using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetDummy : MonoBehaviour, IDamagable
{
    public void TakeDamage(float damageAmount)
    {
        Debug.Log(name + " took " + damageAmount + " damage");
    }
}
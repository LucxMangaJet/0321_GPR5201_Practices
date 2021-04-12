using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour, IEffectedDamagable
{
    [SerializeField] ArrowDamageResponse arrowResponse;
    [SerializeField] PhysicMaterial bounceMaterial;

    private void Start()
    {
        Collider collider = GetComponent<Collider>();

        if (arrowResponse == ArrowDamageResponse.Reflect)
        {
            collider.material = bounceMaterial;
        }
    }

    public ArrowDamageResponse TakeArrowDamage(float damageAmount)
    {
        if (arrowResponse != ArrowDamageResponse.Reflect)
            TakeDamage(damageAmount);

        return arrowResponse;
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log(name + " took " + damageAmount + " damage");
    }

}

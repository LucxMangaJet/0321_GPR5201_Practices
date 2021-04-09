using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float damage = 10;
    [SerializeField] AnimationCurve followDirectionCurve;
    [SerializeField] float lifeTime;

    Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        if (lifeTime > 0)
            Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        float strength = followDirectionCurve.Evaluate(rigidbody.velocity.magnitude);
         transform.forward =Vector3.Lerp(transform.forward, rigidbody.velocity, strength * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.collider.GetComponent<IDamagable>();
        if (damagable != null)
        {
            if(damage > 0)
            {
                damagable.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}

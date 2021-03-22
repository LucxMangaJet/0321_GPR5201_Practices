using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void TakeDamage(float amount);
}

public class HeathComponent : MonoBehaviour, IDamagable
{
    [SerializeField] float maxHealth;

    private float health;
    private bool isDead;

    public event System.Action<HeathComponent> Hit;
    public event System.Action<HeathComponent> Death;

    public float Health { get => health; }
    public bool IsAlive { get => !isDead; }

    private void Start()
    {
        health = maxHealth;
        Hit?.Invoke(this);
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        health -= amount;
        if (health <= 0)
        {
            Death?.Invoke(this);
            isDead = true;
            health = 0;
        }
        Hit.Invoke(this);
    }

    public float GetPercentHealth()
    {
        if (maxHealth == 0)
            return 0;
        return health / maxHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFireEffectDefinition : EffectDefinitionComponet
{
    [SerializeField] GameObject vfxPrefab;
    [SerializeField] float burnDuration;
    [SerializeField] float burnDamage;

    protected override void ApplyEffect(EffectParams parameters)
    {
        var go = Instantiate(vfxPrefab, parameters.Target.transform.position, Quaternion.identity, parameters.Target.transform);
        if (burnDuration > 0)
        {
            Destroy(go, burnDuration);
        }

        StartCoroutine(BurnRoutine(parameters.Damagable, burnDuration, burnDamage));
    }

    private IEnumerator BurnRoutine(IDamagable target, float duration, float burnDamage)
    {
        while (duration > 0)
        {
            yield return new WaitForSeconds(1);

            if (target == null)
                yield break;
            target.TakeDamage(burnDamage);
            duration -= 1;
        }
    }
}

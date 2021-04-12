using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEffectDefinition : EffectDefinitionComponet
{
    protected override void ApplyEffect(EffectParams parameters)
    {
        Debug.Log("DebugEffect: " + parameters.Target.name + " hit");
    }
}

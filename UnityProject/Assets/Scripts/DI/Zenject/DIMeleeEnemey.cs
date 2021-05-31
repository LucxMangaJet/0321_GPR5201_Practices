using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DISolution
{
    public interface IEnemy
    {
        Transform transform { get; }
    }

    public class DIMeleeEnemey : MonoBehaviour, IEnemy
    {
        [Zenject.Inject] IEnemyHandler handler;
        [Zenject.Inject] DebugSettings debugSettings;

        private void OnEnable()
        {
            handler.RegisterEnemy(this);
        }

        private void OnDisable()
        {
            handler.UnregisterEnemy(this);
        }

        private void Update()
        {
            if (debugSettings.DisableAI) return;

            var target = handler.GetTarget();
            
            //Attack
        }

    }

}
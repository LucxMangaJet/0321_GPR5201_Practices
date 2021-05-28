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
            var target = handler.GetTarget();
            
            //Attack
        }

    }

}
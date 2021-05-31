using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DISolution
{
    public interface IEnemyHandler
    {
        void RegisterEnemy(IEnemy enemy);
        bool UnregisterEnemy(IEnemy enemy);

        Transform GetTarget();
    }

    public class DIEnemyHandler : MonoBehaviour, IEnemyHandler
    {
        [SerializeField] Transform target;
        [Zenject.Inject] DebugSettings debugSettings;

        private List<IEnemy> enemies = new List<IEnemy>();

        public void RegisterEnemy(IEnemy enemy)
        {
            enemies.Add(enemy);
        }

        public bool UnregisterEnemy(IEnemy enemy)
        {
            return enemies.Remove(enemy);
        }

        public Transform GetTarget()
        {
            return target;
        }

    }
}
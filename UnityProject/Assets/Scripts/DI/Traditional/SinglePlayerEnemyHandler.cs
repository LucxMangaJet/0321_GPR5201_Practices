using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TraditionalSolution
{
    public class SinglePlayerEnemyHandler : MonoBehaviour
    {
        private static SinglePlayerEnemyHandler instance;

        [SerializeField] Transform target;

        private List<MeleeEnemy> enemies;

        public static SinglePlayerEnemyHandler Instance { get => instance; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                enemies = new List<MeleeEnemy>();
            }
            else
            {
                Debug.LogWarning("Second EnemyHandler found. Destroying.");
                Destroy(this);
            }
        }

        public void RegisterEnemy(MeleeEnemy enemy)
        {
            enemies.Add(enemy);
        }

        public bool UnregisterEnemy(MeleeEnemy enemy)
        {
            return enemies.Remove(enemy);
        }

        public Transform GetTarget()
        {
            return target;
        }
    }
}

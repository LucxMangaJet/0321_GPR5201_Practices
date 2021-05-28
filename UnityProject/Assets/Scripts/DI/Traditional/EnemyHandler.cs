using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TraditionalSolution
{
    public class EnemyHandler : MonoBehaviour
    {
        private static EnemyHandler instance;

        [SerializeField] Transform target;
        
        private List<MeleeEnemy> enemies;

        public static EnemyHandler Instance => instance;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                enemies = new List<MeleeEnemy>();
            }
            else
            {
                Debug.LogWarning ("Second EnemyHandler found. Destroying.");
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

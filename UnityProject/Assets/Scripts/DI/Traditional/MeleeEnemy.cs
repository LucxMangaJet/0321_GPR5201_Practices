using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TraditionalSolution
{
    public class MeleeEnemy : MonoBehaviour
    {
        private void OnEnable()
        {
            EnemyHandler.Instance.RegisterEnemy(this);
        }

        private void OnDisable()
        {
            EnemyHandler.Instance.UnregisterEnemy(this);
        }


        private void Update()
        {
            var target = EnemyHandler.Instance.GetTarget();

            //Attack target
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TraditionalSolution
{
    public class MeleeEnemy : MonoBehaviour
    {
        private void OnEnable()
        {
            SinglePlayerEnemyHandler.Instance.RegisterEnemy(this);
        }

        private void OnDisable()
        {
            SinglePlayerEnemyHandler.Instance.UnregisterEnemy(this);
        }


        private void Update()
        {
            var target = SinglePlayerEnemyHandler.Instance.GetTarget();

            //Attack target
        }
    }

}

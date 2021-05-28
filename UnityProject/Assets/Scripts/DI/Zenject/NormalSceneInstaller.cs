using UnityEngine;
using Zenject;

namespace DISolution
{
    public class NormalSceneInstaller : MonoInstaller
    {
        [SerializeField] DIEnemyHandler enemyHandler;

        public override void InstallBindings()
        {
            Container.Bind<IEnemyHandler>().FromInstance(enemyHandler);
        }
    }
}
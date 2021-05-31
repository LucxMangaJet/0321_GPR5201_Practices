using UnityEngine;
using Zenject;

public class ProjectSettingsInstaller : MonoInstaller
{
    [SerializeField] DebugSettings debugSettings;
    public override void InstallBindings()
    {
        Container.Bind<DebugSettings>().FromScriptableObject(debugSettings);
    }
}
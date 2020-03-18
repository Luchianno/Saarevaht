using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField]
    protected AppSettings settings;

    public override void InstallBindings()
    {
        Container.Bind<AppSettings>().FromNewScriptableObject(settings).AsSingle();
        Container.Bind<string>().WithId("CurrentPath").AsSingle();
    }
}
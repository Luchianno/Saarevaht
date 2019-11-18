using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField]
    protected AppSettings settings;

    public override void InstallBindings()
    {
        Container.BindInstance<AppSettings>(settings);
    }
}
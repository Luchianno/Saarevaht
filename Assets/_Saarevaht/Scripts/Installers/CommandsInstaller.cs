using UnityEngine;
using Zenject;
// using Zenject.

public class CommandsInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        // Container.Bind<AbstractCommand>().To(x => x.AllTypes().DerivingFrom<AbstractCommand>());

        Container.Bind<AbstractCommand>().To<AddObjectToScene>().AsTransient();

        Container.DeclareSignal<CommandSignal>().WithId("AddObjectToScene");
        Container.DeclareSignal<CommandSignal>().WithId("RemoveObjectFromScene");

        Container.DeclareSignal<CommandSignal>().WithId("SelectObject");
        Container.DeclareSignal<CommandSignal>().WithId("DeselectAll");
        Container.DeclareSignal<CommandSignal>().WithId("ChangeObjectPosition");
    }
}
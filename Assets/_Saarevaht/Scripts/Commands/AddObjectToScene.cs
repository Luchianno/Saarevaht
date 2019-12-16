using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class AddObjectToScene : AbstractCommand
{
    ObjectInstance.Factory factory;

    ObjectInstance instance;

    public AddObjectToScene(ObjectInstance.Factory objectInstanceFactory)
    {
        this.factory = objectInstanceFactory;
    }

    public override void Do(object context, object target)
    {
        Utils.IsType<LevelEditorState>(context);
        Utils.IsType<PrefabInstance>(context);

        var prefab = target as PrefabInstance;

        instance = factory.Create(prefab.ReferencedPrefab);
        instance.Position = Vector3.zero; // TODO change spawn position
    }

    public override void Undo(object context)
    {
        instance.Dispose();
    }
}

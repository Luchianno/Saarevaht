using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class AddObjectToScene : AbstractCommand
{
    public AddObjectToScene([Inject(Id = "SceneData")]Transform SceneData)
    {

    }



    public override void Do(object context, object target)
    {
        Utils.IsType<LevelEditorState>(context);
        Utils.IsType<PrefabInstance>(context);

        // var prefab = target as PrefabInstance;

        // TODO position?

        // var = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity)

        // context.
    }

    public override void Undo(object context)
    {
        throw new System.NotImplementedException();
    }
}

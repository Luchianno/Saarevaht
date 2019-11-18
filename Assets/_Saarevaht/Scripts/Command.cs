using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    //LevelEditorContext context
    public abstract void Do(object context, object target);


    // Update is called once per frame
    public abstract void Undo(object context);
}

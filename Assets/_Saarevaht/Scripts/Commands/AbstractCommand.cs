using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCommand
{
    public abstract void Do(object context, object target);

    public abstract void Undo(object context);
}

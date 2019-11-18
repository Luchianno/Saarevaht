using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UndoSystem
{
    public int UndoCount => undo.Count;
    public int RedoCount => redo.Count;

    Stack<CommandInstance> undo = new Stack<CommandInstance>();
    Stack<CommandInstance> redo = new Stack<CommandInstance>();

    [Inject]
    object context;

    public void Reset()
    {
        undo.Clear();
        redo.Clear();
    }

    public void Do(Command cmd, object input)
    {
        cmd.Do(context, input);
        undo.Push(new CommandInstance());
        redo.Clear(); // Once we issue a new command, the redo stack clears
    }
    public void Undo()
    {
        if (undo.Count == 0)
        {
            Debug.LogError("Nothing to undo");
            return;
        }

        CommandInstance cmd = undo.Pop();
        // cmd.Undo();
        redo.Push(cmd);
    }

    public void Redo()
    {
        if (redo.Count == 0)
        {
            Debug.LogError("Nothing to redo");
            return;
        }

        var cmd = redo.Pop();
        // cmd.Do();
        undo.Push(cmd);
    }

}

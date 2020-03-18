using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UndoSystem
{
    public int MaxSize = 100;

    public int UndoCount => undo.Count;
    public int RedoCount => redo.Count;

    LinkedList<CommandInstance> undo = new LinkedList<CommandInstance>();
    LinkedList<CommandInstance> redo = new LinkedList<CommandInstance>();

    [Inject]
    protected object context;

    public void Reset()
    {
        undo.Clear();
        redo.Clear();
    }

    public void Do(AbstractCommand cmd, object input)
    {
        if (undo.Count == MaxSize)
        {
            // TODO needs disposing?
            undo.RemoveFirst();
        }

        cmd.Do(context, input);
        undo.AddLast(new CommandInstance());
        redo.Clear(); // Once we issue a new command, the redo stack clears
    }
    public void Undo()
    {
        if (undo.Count == 0)
        {
            Debug.LogError("Nothing to undo");
            return;
        }

        CommandInstance cmd = undo.Last.Value;
        undo.RemoveLast();
        // TODO
        // cmd.Undo();

        if (redo.Count == MaxSize)
        {
            redo.RemoveFirst();
        }

        redo.AddLast(cmd);
    }

    public void Redo()
    {
        if (redo.Count == 0)
        {
            Debug.LogError("Nothing to redo");
            return;
        }

        var cmd = redo.Last.Value;
        redo.RemoveLast();
        // cmd.Do();

        // this should not happen right? because it's redo
        // but anyway
        if (undo.Count == MaxSize)
        {
            // TODO needs disposing?
            undo.RemoveFirst();
        }

        undo.AddLast(cmd);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CommandInstance
{
    public AbstractCommand Command { get; protected set; }

    public object Context;
    public object Target;



}

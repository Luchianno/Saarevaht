using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LevelData: IDisposable
{
    [SerializeField]
    public string Version = "1";

    public List<ObjectInstance> Items;

    public void Dispose()
    {
        // throw new NotImplementedException();
    }
}

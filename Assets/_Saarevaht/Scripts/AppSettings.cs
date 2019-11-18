using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Saarevaht/AppSettings")]
public class AppSettings : ScriptableObject
{
    public string LevelSaveLocation;

    public string DefaultSavePath => throw new NotImplementedException(); // TODO default save location for files
}

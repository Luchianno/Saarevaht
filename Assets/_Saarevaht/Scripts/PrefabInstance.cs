using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Saarevaht/PrefabInstance")]
public class PrefabInstance : ScriptableObject
{
    public string Name;

    public GameObject ReferencedPrefab;

    public List<string> Tags;

    public string Category;
    
}

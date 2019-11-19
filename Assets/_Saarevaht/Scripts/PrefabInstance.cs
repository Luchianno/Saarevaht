using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Saarevaht/PrefabInstance")]
public class PrefabInstance : ScriptableObject
{
    public string Name;

    public GameObject ReferencedPrefab;

    public HashSet<string> Tags = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    public string Category;
}

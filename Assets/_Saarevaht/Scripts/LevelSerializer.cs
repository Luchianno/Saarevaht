using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;
using Zenject;

public class LevelSerializer : MonoBehaviour, ILevelSerializer
{
    [Inject]
    AppSettings settings;

    public LevelData Deserialize(string path)
    {
        // var path = "";
        var json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<LevelData>(json);
    }

    // Update is called once per frame
    public void Serialize(LevelData level, string path)
    {
        var serialized = JsonConvert.SerializeObject(level, Formatting.Indented);
        File.WriteAllText(path, serialized);
    }
}

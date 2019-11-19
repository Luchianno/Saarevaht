using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;
using Zenject;

public class LevelSerializer : MonoBehaviour
{
    [Inject]
    AppSettings settings;

    LevelData Deserialize()
    {
        var path = "";
        var json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<LevelData>(json);
    }

    // Update is called once per frame
    void Serialize(LevelData level)
    {
        var path = "";
        var serialized = JsonConvert.SerializeObject(level, Formatting.Indented);
        File.WriteAllText(path, serialized);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelSerializer
{
    LevelData Deserialize(string path);

    void Serialize(LevelData level, string path);
}

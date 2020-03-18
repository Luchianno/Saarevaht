using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelSerializationController : MonoBehaviour
{
    [Inject]
    ILevelSerializer serializer;

    // can be null
    [Inject]
    LevelData levelData;

    SignalBus signalBus;

    void Start()
    {
        signalBus.SubscribeId<string>("NewLevel", NewLevel);
        signalBus.SubscribeId<string>("LoadLevel", LoadLevel);
        signalBus.SubscribeId<string>("SaveLevel", SaveLevel);
        signalBus.SubscribeId<string>("SaveLevelAs", SaveLevelAs);
    }

    public void NewLevel()
    {
        levelData?.Dispose();
        levelData = new LevelData();
    }

    public void LoadLevel(string path)
    {
        levelData?.Dispose();
        levelData = serializer.Deserialize(path); // inject back?
    }

    public void SaveLevel()
    {
        var path = ""; // get path of currently open project from somewehere
        serializer.Serialize(levelData, path);

    }

    public void SaveLevelAs(string path)
    {
        serializer.Serialize(levelData, path);
    }
}

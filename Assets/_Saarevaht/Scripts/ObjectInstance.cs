using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
using Newtonsoft.Json;

[Serializable]
public class ObjectInstance: IDisposable
{
    public Guid Id;
    public string PrefabId;
    public Vector3 Position
    {
        get { return SceneObject.transform.position; }
        set { SceneObject.transform.position = value; }
    }
    public Quaternion Rotation
    {
        get { return SceneObject.transform.rotation; }
        set { SceneObject.transform.rotation = value; }
    }

    [NonSerialized]
    public GameObject SceneObject;

    public class Factory : PlaceholderFactory<ObjectInstance>
    {
    }

    public void Dispose()
    {
        GameObject.Destroy(this.SceneObject.gameObject);
    }
}
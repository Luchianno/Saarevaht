﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
using Newtonsoft.Json;

[Serializable]
public class ObjectInstance : IDisposable
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

    public ObjectInstance(GameObject prefab, Vector3 position = default, Quaternion rotation = default) : this(prefab, Guid.NewGuid(), position, rotation) { }

    public ObjectInstance(GameObject prefab, Guid guid, Vector3 position = default, Quaternion rotation = default)
    {
        Id = guid;
        GameObject.Instantiate(prefab);
    }

    public class Factory : PlaceholderFactory<GameObject, ObjectInstance>
    {
        public override ObjectInstance Create(GameObject param)
        {
            var result = base.Create(param);
            result.Id = Guid.NewGuid();
            return result;
        }
    }

    public void Dispose()
    {
        GameObject.Destroy(this.SceneObject.gameObject);
    }
}
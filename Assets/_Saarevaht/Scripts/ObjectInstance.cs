using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
using Newtonsoft.Json;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[Serializable]
public class ObjectInstance : IDisposable
{
    public Guid Guid { get; protected set; }
    public string PrefabId { get; protected set; }
    public Vector3 Position
    {
        get { return position; }
        set
        {
            position = value;
            UpdateReferencedObject();
        }
    }

    public Quaternion Rotation
    {
        get { return rotation; }
        set
        {
            rotation = value;
            UpdateReferencedObject();
        }
    }

    [JsonIgnore]
    public GameObject SceneObject { get; protected set; }

    Vector3 position;
    Quaternion rotation;

    public ObjectInstance(string prefabId, Vector3 position = default, Quaternion rotation = default) : this(prefabId, Guid.NewGuid(), position, rotation) { }

    [JsonConstructor]
    public ObjectInstance(string prefabId, Guid guid, Vector3 position = default, Quaternion rotation = default)
    {
        this.PrefabId = prefabId;
        this.Guid = guid;
        this.Position = position;
        this.Rotation = rotation;
    }

    public void CreateSceneObject()
    {
        Addressables.Instance.InstantiateAsync<GameObject>(PrefabId, position, rotation).Completed += ObjectLoaded;
        // GameObject.Instantiate(this.Prefab, position, rotation);
    }

    private void ObjectLoaded(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Result == null)
        {
            Debug.LogError("load fail");
            return;
        }

        this.SceneObject = obj.Result;
    }

    public void UpdateReferencedObject()
    {
        if (SceneObject != null)
        {
            SceneObject.transform.SetPositionAndRotation(position, rotation);
        }
    }

    // public class Factory : PlaceholderFactory<GameObject, ObjectInstance>
    // {
    //     public override ObjectInstance Create(GameObject param)
    //     {
    //         var result = base.Create(param);
    //         result.Id = Guid.NewGuid();
    //         return result;
    //     }
    // }

    public void Dispose()
    {
        GameObject.Destroy(this.SceneObject.gameObject);
    }
}
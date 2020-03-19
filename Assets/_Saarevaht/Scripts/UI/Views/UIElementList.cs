using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;
using System;

public class UIElementList<T> : MonoBehaviour where T : Behaviour
{
    [SerializeField]
    protected GameObject prefab;

    protected List<T> cache = new List<T>();
    // List<GameObject> cache;

    [SerializeField]
    protected RectTransform parent;

    protected virtual void Awake()
    {
        Clear();
    }

    public virtual void Clear()
    {
        foreach (RectTransform item in parent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in cache)
        {
            Destroy(item.gameObject);
        }
        cache.Clear();
    }

    public virtual void Load<V>(IEnumerable<V> list, Action<T, V> init)
    {
        if (init is null)
        {
            throw new ArgumentNullException(nameof(init));
        }

        Clear();

        foreach (var item in list)
        {
            var tempObject = Instantiate(prefab, parent, false);
            var component = tempObject.GetComponent<T>();
            if (component == null)
            {
                throw new Exception("Component not found");
            }
            init(component, item);

            cache.Add(component);
        }
    }
}

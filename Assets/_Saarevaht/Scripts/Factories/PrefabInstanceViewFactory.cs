using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PrefabInstanceViewFactory : IFactory<PrefabInstance, RectTransform, PrefabInstanceView>
{
    DiContainer container;
    GameObject prefab;

    public PrefabInstanceViewFactory(DiContainer container, [Inject(Id = "PrefabInstanceViewPrefab")] GameObject prefab)
    {
        this.container = container;
        this.prefab = prefab;
    }

    public PrefabInstanceView Create(PrefabInstance param, RectTransform parent)
    {
        var temp = container.InstantiatePrefabForComponent<PrefabInstanceView>(prefab, parent);
        temp.Data = param;
        return temp;
    }
}

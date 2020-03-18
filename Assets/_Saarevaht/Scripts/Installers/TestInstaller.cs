using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    public List<PrefabInstance> TestPrefabs;

    public GameObject viewPrefab;

    public override void InstallBindings()
    {
        Container.BindInstance<GameObject>(viewPrefab).WithId("PrefabInstanceViewPrefab");
        Container.BindFactory<PrefabInstance, RectTransform, PrefabInstanceView, PrefabInstanceView.Factory>().FromFactory<PrefabInstanceViewFactory>();
    }

    public override void Start()
    {
        base.Start();
        GameObject.FindObjectOfType<PrefabExplorerView>().Load(TestPrefabs);
    }
}
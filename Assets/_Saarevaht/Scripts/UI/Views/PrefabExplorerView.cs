using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using System;

[DisallowMultipleComponent]
public class PrefabExplorerView : MonoBehaviour
{
    List<PrefabInstance> cache = new List<PrefabInstance>();
    List<PrefabInstanceView> previewList = new List<PrefabInstanceView>();
    HashSet<string> categories = new HashSet<string>();
    HashSet<string> tags = new HashSet<string>();

    [Inject]
    protected PrefabInstanceView.Factory previewFactory;

    [SerializeField]
    RectTransform previewParent;
    [SerializeField]
    ToggleListView categoriesView;

    public void Start()
    {
        categoriesView.ToggleListChanged += OnSelectedCategoriesChanged;
        foreach (RectTransform item in previewParent)
        {
            Destroy(item.gameObject);
        }
    }

    private void OnSelectedCategoriesChanged()
    {
        // disable layout

        // disable elements with wrong category
        foreach (var item in previewList)
        {
            item.gameObject.SetActive(categoriesView.ActiveToggles.Contains(item.Data.Category));
        }

        // enable layout
    }

    public void Load(IEnumerable<PrefabInstance> prefabs)
    {
        Clear();

        cache.AddRange(prefabs);
        foreach (var item in prefabs)
        {
            var temp = previewFactory.Create(item, previewParent);
            temp.OnClick += OnItemClicked;
            previewList.Add(temp);

            categories.Add(item.Category);

            foreach (var tag in item.Tags)
            {
                tags.Add(tag);
            }
        }

        categoriesView.Load(categories);
        // scrollRect.verticalNormalizedPosition = 1; // scroll up
        // reset layout elements?
    }

    private void OnItemClicked(PrefabInstanceView obj)
    {
        Debug.Log(obj.Data.name + "clicked");
    }

    public void Clear()
    {
        categories.Clear();
        tags.Clear();

        cache.Clear();

        foreach (var item in previewList)
        {
            Destroy(item.gameObject);
        }
        previewList.Clear();

        categoriesView.Clear();
    }
}

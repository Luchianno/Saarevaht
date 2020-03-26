using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;

[DisallowMultipleComponent]
public class PrefabExplorerView : UIElementList<PrefabInstanceView>
{
    List<PrefabInstance> data = new List<PrefabInstance>();
    HashSet<string> categories = new HashSet<string>();
    HashSet<string> tags = new HashSet<string>();

    [Inject]
    protected PrefabInstanceView.Factory previewFactory;
    [Inject]
    protected SignalBus signalBus;

    [SerializeField]
    TMP_InputField inputField;
    [SerializeField]
    RectTransform previewParent;
    [SerializeField]
    ToggleListView categoriesView;
    [SerializeField]
    ToggleListView tagsView;

    public void Start()
    {
        categoriesView.ToggleListChanged += OnFilterParamsChanged;
        tagsView.ToggleListChanged += OnFilterParamsChanged;
        inputField.onValueChanged.AddListener(_ => OnFilterParamsChanged());// += OnInputFieldValueChanged;
    }


    private void OnFilterParamsChanged()
    {
        // disable layout

        // disable elements with wrong category
        foreach (var item in cache)
        {
            item.gameObject.SetActive(categoriesView.ActiveToggles.Contains(item.Data.Category)
                && tagsView.ActiveToggles.Intersect(item.Data.Tags).Any()
                && (string.IsNullOrWhiteSpace(inputField.text) || item.Data.Name.Contains(inputField.text, StringComparison.InvariantCultureIgnoreCase)));
        }

        // enable layout
    }

    public void Load(IEnumerable<PrefabInstance> prefabs)
    {
        base.Load<PrefabInstance>(prefabs, (component, param) =>
        {
            component.Data = param;
            component.OnClick += OnItemClicked;

            categories.Add(param.Category);
            tags.UnionWith(param.Tags);
        });

        categoriesView.Load(categories);
        tagsView.Load(tags);
        // scrollRect.verticalNormalizedPosition = 1; // scroll up
        // reset layout elements?
    }

    private void OnItemClicked(PrefabInstanceView obj)
    {
        Debug.Log(obj.Data.name + "clicked");
        signalBus.Fire<CommandSignal>(new CommandSignal()
        {
            Name = "AddObjectToScene",
            Target = obj.Data
        });
    }

    public override void Clear()
    {
        base.Clear();

        categories.Clear();
        tags.Clear();
        data.Clear();

        categoriesView.Clear();
        tagsView.Clear();
    }
}

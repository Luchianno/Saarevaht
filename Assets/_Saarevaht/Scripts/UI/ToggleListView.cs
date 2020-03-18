using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(ToggleGroup))]
public class ToggleListView : MonoBehaviour
{
    public ICollection<string> ActiveToggles => activeToggles;

    public event Action ToggleListChanged;

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    RectTransform parent;

    HashSet<string> activeToggles = new HashSet<string>();
    Dictionary<ExtensionsToggle, string> cache = new Dictionary<ExtensionsToggle, string>();

    public void Clear()
    {
        foreach (RectTransform item in parent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in cache.Keys)
        {
            Destroy(item.gameObject);
        }
        cache.Clear();

        activeToggles.Clear();
    }

    public void Load(IEnumerable<string> list)
    {
        Clear();

        foreach (var item in list)
        {
            var temp = Instantiate(prefab, parent, false);
            var toggle = temp.GetComponent<ExtensionsToggle>();
            var textComponent = temp.GetComponentInChildren<TextMeshProUGUI>();

            toggle.onToggleChanged.AddListener(OnToggleChanged);
            textComponent.text = item;

            cache.Add(toggle, item);
        }
    }

    void OnToggleChanged(ExtensionsToggle toggle)
    {
        if (toggle.IsOn)
        {
            activeToggles.Add(cache[toggle]);
        }
        else
        {
            activeToggles.Remove(cache[toggle]);
        }

        ToggleListChanged?.Invoke();
    }

}

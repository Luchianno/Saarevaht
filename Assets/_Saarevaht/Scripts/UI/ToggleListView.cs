using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class ToggleListView : UIElementList<ExtensionsToggle>
{
    public bool ToggleOnByDefault = true;

    public ICollection<string> ActiveToggles => activeToggles;

    public event Action ToggleListChanged;

    protected HashSet<string> activeToggles = new HashSet<string>();

    protected Dictionary<ExtensionsToggle, string> pairs = new Dictionary<ExtensionsToggle, string>();

    public override void Clear()
    {
        base.Clear();

        activeToggles.Clear();
    }

    public void Load(IEnumerable<string> list)
    {
        base.Load<string>(list, (obj, label) =>
        {
            var toggle = obj.GetComponent<ExtensionsToggle>();
            var textComponent = obj.GetComponentInChildren<TextMeshProUGUI>();
                        
            toggle.onToggleChanged.AddListener(OnToggleChanged);
            toggle.IsOn = ToggleOnByDefault;

            pairs.Add(toggle, label);

            OnToggleChanged(toggle); // we need to manually call this for initialization

            textComponent.text = label;
        });

    }

    void OnToggleChanged(ExtensionsToggle toggle)
    {
        if (toggle.IsOn)
        {
            activeToggles.Add(pairs[toggle]);
        }
        else
        {
            activeToggles.Remove(pairs[toggle]);
        }

        ToggleListChanged?.Invoke();
    }

}

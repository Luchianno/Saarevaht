using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;
using System;

public class PrefabInstanceView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI title;
    [SerializeField]
    Image preview;
    [SerializeField]
    Button button;

    public Action<PrefabInstanceView> OnClick;

    public PrefabInstance Data
    {
        get { return data; }
        set
        {
            data = value;
            UpdateView();
        }
    }

    PrefabInstance data;

    void Start()
    {
        button.onClick.AddListener(() => OnClick?.Invoke(this));
    }

    public void UpdateView()
    {
        this.title.text = data?.Name ?? string.Empty;
        // TODO Generate Preview;
        this.preview.sprite = null;
    }

    public class Factory : PlaceholderFactory<PrefabInstance, RectTransform, PrefabInstanceView> { }
}

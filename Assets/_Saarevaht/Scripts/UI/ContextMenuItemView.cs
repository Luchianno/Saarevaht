using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ContextMenuItemView : MonoBehaviour
{
    [SerializeField]
    protected Image Icon;
    [SerializeField]
    protected TextMeshProUGUI Label;
    [SerializeField]
    protected Button button;

    public event Action<ContextMenuItemView> OnClick;

    public string Id;

    void Start() => button.onClick.AddListener(() => OnClick?.Invoke(this));

    public void Init(string Label, Sprite icon = null, string id = null)
    {
        this.Id = id;
        this.Label.text = Label;
        this.Icon.sprite = icon;
    }
}

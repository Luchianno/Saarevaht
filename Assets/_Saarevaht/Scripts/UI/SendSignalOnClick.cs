using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class SendSignalOnClick : MonoBehaviour
{
    Button button;

    public string EventString;

    [Inject]
    SignalBus bus;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => bus.Fire<string>(EventString));
    }

}

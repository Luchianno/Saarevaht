using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine;
using Zenject;

public class DoozyEventRouter
{
    [Inject]
    SignalBus signalBus;

    private void OnEnable() { RegisterListener(); }

    private void OnDisable() { UnregisterListener(); }

    private void RegisterListener()
    {
        Message.AddListener<GameEventMessage>(OnMessage);
    }

    private void UnregisterListener()
    {
        Message.RemoveListener<GameEventMessage>(OnMessage);
    }

    private void OnMessage(GameEventMessage message)
    {
        if (!message.HasGameEvent)
            return;

        signalBus.Fire<DoozyGameEventSignal>(new DoozyGameEventSignal(message.EventName));
    }

}

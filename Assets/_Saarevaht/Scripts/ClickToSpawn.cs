// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;
// using Zenject;
// using Doozy.Engine;
// using System;

// public class ClickToSpawn : MonoBehaviour, IPointerClickHandler
// {
//     [Inject(Id = "TestPrefab")]
//     protected GameObject TestPrefab;

//     public void OnPointerClick(PointerEventData eventData)
//     {
//         sceneManager.AddObject(sceneManager.SelectedFurniture, eventData.position);
//         GameEventMessage.SendEvent("SceneItemSelected");
//     }

// }

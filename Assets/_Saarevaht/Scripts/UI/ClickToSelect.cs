// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using Zenject;

// public class ClickToSelect : MonoBehaviour, IPointerClickHandler
// {
//     [Inject]
//     protected SceneManager selection;

//     [SerializeField]
//     new Camera camera;
//     [SerializeField]
//     LayerMask layerMask;
//     [SerializeField]
//     LayerMask tableLayerMask;

//     public void OnPointerClick(PointerEventData eventData)
//     {
//         var ray = camera.ScreenPointToRay(eventData.position);

//         if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
//         {
//             if (hit.collider.gameObject.layer == tableLayerMask)
//             {
//                 Debug.Log("virtual surface  ");
//             }
//             var temp = hit.collider.gameObject;

//             Debug.Log("selected: " + temp.gameObject.name);
//             // Debug.Log("2: " + eventData.pointerCurrentRaycast.gameObject.name);
//             selection.SelectWorldObject(temp.GetComponent<SpawnedItemView>());
//             Doozy.Engine.GameEventMessage.SendEvent("SceneItemSelected");
//         }
//         else
//         {
//             Debug.Log("miss");
//         }
//     }

// }

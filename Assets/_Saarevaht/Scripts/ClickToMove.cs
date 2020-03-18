// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using Zenject;

// public class ClickToMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     public LayerMask layerMask;

//     [Inject]
//     protected new Camera camera;

//     [Inject]
//     protected SceneManager sceneManager;

//     [Inject]
//     protected ARRaycastManager raycastManager;

//     List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

//     bool selected = false;

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         var ray = camera.ScreenPointToRay(eventData.position);

//         if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
//         {
//             selected = true;
//         }
//         else
//         {
//             selected = false;
//         }
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         if (!selected)
//         {
//             return;
//         }
//         var ray = camera.ScreenPointToRay(eventData.position);

//         if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask)
//             && hit.collider.gameObject != sceneManager.SelectedWorldObject.gameObject)
//         {
//             Debug.Log(hit.collider.gameObject.name);
//             return;
//         }
//         else if (raycastManager.Raycast(eventData.position, s_Hits, TrackableType.PlaneWithinPolygon))
//         {
//             var hitPosition = s_Hits[0].pose.position;

//             sceneManager.SelectedWorldObject.transform.position = hitPosition;
//         }
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         selected = false;
//     }
// }

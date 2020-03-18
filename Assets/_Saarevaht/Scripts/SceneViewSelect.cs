using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using UnityEngine.EventSystems;
using Zenject;

/*
NB: when you release mouse button OnPointerClick is called before OnEndDrag


*/


[RequireComponent(typeof(NonDrawingGraphic))]
public class SceneViewSelect : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Camera SelectionCamera;

    public LayerMask SelectionMask;

    bool isClick = true;

    public GameObject Selected;

    [Inject]
    SignalBus bus;

    public void OnBeginDrag(PointerEventData eventData)
    {
        isClick = false;
        // Debug.Log("ha!");
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("onEndDrag");
        SelectionCamera.ScreenPointToRay(eventData.position);
        // Physics.OverlapBoxNonAlloc()
        isClick = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click!");
        if (!isClick)
            return;
        var ray = SelectionCamera.ScreenPointToRay(eventData.position);

        // we hit something
        // TODO should go thorugh all the stuff
        if (Physics.Raycast(ray, out RaycastHit hit, SelectionMask))
        {
            // it's the same object
            if (Selected == hit.transform.gameObject)
            {
                // try to select next thing on the way of ray
            }
            else
            {
                Selected = hit.transform.gameObject;
              
                // propagate the event
                bus.Fire<CommandSignal>(new CommandSignal()
                {
                    Name = "SelectObject",
                    Target = Selected,
                });
            }
        }
        else
        {
            Selected = null;
        }

        // throw new System.NotImplementedException();
    }
}

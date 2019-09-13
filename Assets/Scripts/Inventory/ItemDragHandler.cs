using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public IInventoryItem Item { get; set; }
    public void OnDrag(PointerEventData eventData)
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 0);
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
        transform.localScale = new Vector3(1, 1, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class radialbutton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image circle;
    public Image icon;
    public string title;
    public GameObject HUD;
    public IInventoryItem inventoryItem;

    Color defaultColor;

    public void OnPointerEnter (PointerEventData eventData)
    {
        GameObject.Find("Inventory").GetComponent<Inventory>().Selected = this;
        defaultColor = circle.color;
        circle.color = Color.white;
    }

    public void OnPointerExit (PointerEventData eventData)
    {
        StartCoroutine(DeselectItem(0.001F));
        circle.color = defaultColor;
    }

    IEnumerator DeselectItem(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        if (Input.touchCount > 0)
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().Selected = null;
        }
    }
}

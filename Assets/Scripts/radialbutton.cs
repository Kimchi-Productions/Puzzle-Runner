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
    public radialmenu myMenu;

    Color defaultColor;

    // Start is called before the first frame update
    public void OnPointerEnter (PointerEventData eventData)
    {
        myMenu.selected = this;
        defaultColor = circle.color;
        circle.color = Color.white;
    }

    // Update is called once per frame
    public void OnPointerExit (PointerEventData eventData)
    {
        myMenu.selected = null;
        circle.color = defaultColor;
    }
}

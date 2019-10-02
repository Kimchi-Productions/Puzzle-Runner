using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radialmenuspawner : MonoBehaviour
{
    public static radialmenuspawner ins;
    public radialmenu menuPrefab;
    public GameObject GhostItem;
    public GameObject ghostObject;

    void Awake()
    {
        ins = this;
    }

    public void SpawnMenu(Vector3 mousePosition)
    {   
        radialmenu newMenu = Instantiate(menuPrefab) as radialmenu;
        newMenu.transform.SetParent (transform, false);
        newMenu.GetComponent<RectTransform>().anchorMax = Camera.main.ScreenToViewportPoint(new Vector2(mousePosition.x, mousePosition.y));
        newMenu.GetComponent<RectTransform>().anchorMin = Camera.main.ScreenToViewportPoint(new Vector2(mousePosition.x, mousePosition.y));
        transform.Find("Inventory").GetComponent<Inventory>().SpawnButtons(newMenu);

        ghostObject = Instantiate(GhostItem, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log(ghostObject);
    }
}

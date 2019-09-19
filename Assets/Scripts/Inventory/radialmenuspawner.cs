using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radialmenuspawner : MonoBehaviour
{
    public static radialmenuspawner ins;
    public radialmenu menuPrefab;

    void Awake()
    {
        ins = this;
    }

    public void SpawnMenu(Vector3 mousePosition)
    {   
        radialmenu newMenu = Instantiate(menuPrefab) as radialmenu;
        newMenu.transform.SetParent (transform, false);
        newMenu.GetComponent<RectTransform>().anchoredPosition = mousePosition;
        transform.Find("Inventory").GetComponent<Inventory>().SpawnButtons(newMenu);
    }
}

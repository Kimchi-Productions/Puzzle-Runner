using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelmenutrigger : MonoBehaviour
{

    public GameObject HUD;

    //Listen for interaction to open the radial menu
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1f)
        {
            radialmenuspawner.ins.SpawnMenu(Input.mousePosition);
            HUD.transform.Find("Inventory").GetComponent<Inventory>().clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Mousebuttondown click position: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Debug.Log("inventory click position: " + HUD.transform.Find("Inventory").GetComponent<Inventory>().clickPosition);
        }
    }
}

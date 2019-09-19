using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radialmenu : MonoBehaviour
{
    public radialbutton buttonPrefab;
    public radialbutton selected;
    public GameObject HUD;

    public void SpawnButtons() {
        //Spawn radial menu for items in the item array, change to existing inventory system?
    }

    void Update(){
        //TODO when no item selected, do nothing
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(selected);  
            Destroy(gameObject);
        }
    }


}

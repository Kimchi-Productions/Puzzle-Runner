using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radialmenuspawner : MonoBehaviour
{
    public static radialmenuspawner ins;
    public radialmenu menuPrefab;

    void Awake(){
        ins = this;
    }

    public void SpawnMenu(wheelmenutrigger obj){
        radialmenu newMenu = Instantiate(menuPrefab) as radialmenu;
        newMenu.transform.SetParent (transform, false);
        newMenu.transform.position = Input.mousePosition;
        newMenu.SpawnButtons(obj);
    }
}

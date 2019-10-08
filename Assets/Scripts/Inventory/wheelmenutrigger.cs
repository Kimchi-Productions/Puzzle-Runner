using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelmenutrigger : MonoBehaviour
{

    public GameObject HUD;
    public GameObject itemCircle;
    private GameObject itemCircleInstance;

    //Listen for interaction to open the radial menu

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1 && gameObject.GetComponent<Automove>().Speed_X != 0)
        {
            if (Input.mousePosition.x > 88 || Input.mousePosition.y > 88)
            {
                radialmenuspawner.ins.SpawnMenu(Input.mousePosition);
                HUD.transform.Find("Inventory").GetComponent<Inventory>().clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Slow down the game speed
                Time.timeScale = 0.1f;
                itemCircleInstance = Instantiate(itemCircle, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 10), Quaternion.identity);
            }
        }

        if (Input.touches[0].phase == TouchPhase.Ended && Time.timeScale == 0.1f)
        {
            Destroy(itemCircleInstance);
        }
    }
}

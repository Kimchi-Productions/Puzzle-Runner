using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStarsInLevel : MonoBehaviour
{

    public GameObject StarContainerInLevel;
    public static GameObject pass;
    public static Image[] starArr;

    // Start is called before the first frame update
    void Start()
    {
        starArr = StarContainerInLevel.GetComponentsInChildren<Image>();
        pass = StarContainerInLevel;
        pass.SetActive(false);
    }

    public static void showEarnedStars(int a)
    {
        switch (a)
        {
            case 1:
                starArr[0].color = new Color32(255, 255, 255, 255);
                break;
            case 2:
                starArr[0].color = new Color32(255, 255, 255, 255);
                starArr[1].color = new Color32(255, 255, 255, 255);
                break;
        }
    }

    public static void enableStars()
    {
        pass.SetActive(true);
    }

    public static void disableStars()
    {
        pass.SetActive(false);
    }

}

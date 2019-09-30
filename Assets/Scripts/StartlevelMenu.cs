using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartlevelMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startMenuUI;
    void Start()
    {
        Time.timeScale = 0f;
    }
    
    public void startLevel(){
        Time.timeScale = 1f;
        startMenuUI.SetActive(false);
    }
}

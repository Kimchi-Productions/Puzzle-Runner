using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarManagement : MonoBehaviour
{

    public static List<Star> starList = new List<Star>();
    public static int currentLevel;
    public int counter = 1;
	public int getLevels;

    public void Start()
    {
		getLevels = SceneManager.sceneCountInBuildSettings - 2;
		Debug.Log("Level Count: " + getLevels);

        if (Application.platform == RuntimePlatform.Android)
        {
            if (!System.IO.File.Exists((Application.persistentDataPath + "/savedStars.dat")))
            {
                fillList();
                Debug.Log("VUL LIJST");
            }
            else
            {

                SaveSystem.LoadStar();
                Debug.Log("LAAD LIJST!");
                Debug.Log(starList.Count);

                if (starList.Count == getLevels)
                {
                    Debug.Log("Starlist loopt gelijk met de save");
                }
                else
                {
                    Debug.Log("Starlist Loopt niet gelijk met de save");
                    for (int i = starList.Count - 1; i <= getLevels - 1; i++)
                    {
                        starList.Add(new Star("Level-" + i, currentLevel + i, 0));
                    }
                    SaveSystem.SaveStar();
                    Debug.Log(starList.Count);
                }
            }
        }
        else
        {

            if (!System.IO.File.Exists(("savedStars.dat")))
            {
                fillList();
                Debug.Log("VUL LIJST");
            }
            else
            {

                SaveSystem.LoadStar();
                Debug.Log("LAAD LIJST!");
                Debug.Log(starList.Count);

                if (starList.Count == getLevels)
                {
                    Debug.Log("Starlist loopt gelijk met de save");
                }
                else
                {
                    Debug.Log("Loopt niet gelijk");
                    for (int i = starList.Count - 1; i <= getLevels - 1; i++)
                    {
                        starList.Add(new Star("Level-" + i, currentLevel + i, 0));
                    }
                    SaveSystem.SaveStar();
                    Debug.Log(starList.Count);
                }
            }
        }

        
        currentLevel = SceneManager.GetActiveScene().buildIndex -1;
    }

    public void fillList()
    {
        for (int i = 0; i < getLevels; i++)
        {

            if(i > 0)
            {
                counter++;
            }

            starList.Add(new Star("Level-" + counter, currentLevel + i, 0));
        }

        SaveSystem.SaveStar();

    }

    static public void addStar(int getActiveLevel, int addedStars)
    {
        SaveSystem.LoadStar();

        foreach (Star star in starList)
        {

            if (star.level == getActiveLevel)
            {
                star.amountOfStars = addedStars;
                SaveSystem.SaveStar();
            }

        }

    }

}

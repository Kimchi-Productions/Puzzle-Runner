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
            }
            else
            {

                SaveSystem.LoadStar();

                if (starList.Count == getLevels)
                {
                }
                else
                {
                    for (int i = starList.Count - 1; i <= getLevels - 1; i++)
                    {
                        starList.Add(new Star("Level-" + i, currentLevel + i, 0));
                    }
                    SaveSystem.SaveStar();
                }
            }
        }
        else
        {

            if (!System.IO.File.Exists(("savedStars.dat")))
            {
                fillList();
            }
            else
            {

                SaveSystem.LoadStar();

                if (starList.Count == getLevels)
                {
                }
                else
                {
                    for (int i = starList.Count - 1; i <= getLevels - 1; i++)
                    {
                        starList.Add(new Star("Level-" + i, currentLevel + i, 0));
                    }
                    SaveSystem.SaveStar();
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
                if (addedStars > star.amountOfStars)
                {
                    star.amountOfStars = addedStars;
                    SaveSystem.SaveStar();
                }
            } 
        }
    }
}

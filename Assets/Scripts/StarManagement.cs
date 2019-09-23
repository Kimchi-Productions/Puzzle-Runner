using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarManagement : MonoBehaviour
{

    public static List<Star> starList = new List<Star>();
    public static int currentLevel;

    public void Start()
    {
        if (!System.IO.File.Exists("savedStars.dat"))
        {
            fillList();
            Debug.Log("VUL LIJST");
        }
        else
        {
            SaveSystem.LoadStar();
            Debug.Log("LAAD LIJST!");
        }
        
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1;

    }

    public void fillList()
    {
        for (int i = 0; i <= 3; i++)
        {
            starList.Add(new Star("Level-" + i, currentLevel + i, 10));
        }
        SaveSystem.SaveStar();
    }

    static public void addStar(int getActiveLevel)
    {
        SaveSystem.LoadStar();

        foreach (Star star in starList)
        {
            Debug.Log("Heyo " + currentLevel + "heyo : " + getActiveLevel);

            if (currentLevel == getActiveLevel)
            {
                star.amountOfStars += 1;
                SaveSystem.SaveStar();
            }
             
            Debug.Log("amount of stars" + star.amountOfStars);
        }
    }

}

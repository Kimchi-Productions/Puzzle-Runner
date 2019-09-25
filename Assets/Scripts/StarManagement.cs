using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarManagement : MonoBehaviour
{

    public static List<Star> starList = new List<Star>();
    public static int currentLevel;
    public int counter = 1;

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
        
        currentLevel = SceneManager.GetActiveScene().buildIndex -1;

    }

    public void fillList()
    {
        for (int i = 0; i < 2; i++)
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

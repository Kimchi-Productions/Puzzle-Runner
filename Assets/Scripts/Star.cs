using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Star
{
	public string levelName;
	public int level;
	public int amountOfStars;

    public Star(string newLevelName, int newLevel, int newAmountOfStars)
	{
		levelName = newLevelName;
		level = newLevel;
		amountOfStars = newAmountOfStars;
	}

}

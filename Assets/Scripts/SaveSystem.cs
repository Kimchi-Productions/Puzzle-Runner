using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSystem
{
    public static FileStream stream;
    public static FileStream file;

    public static void SaveStar()
    { 
        BinaryFormatter formatter = new BinaryFormatter();
        if(Application.platform == RuntimePlatform.Android)
        {
            stream = new FileStream(Application.persistentDataPath + "/savedStars.dat", FileMode.Create);
        }
        else
        {
            stream = new FileStream("savedStars.dat", FileMode.Create);
        }
        formatter.Serialize(stream, StarManagement.starList);
        stream.Close();


    }

    public static void LoadStar()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (Application.platform == RuntimePlatform.Android)
        {
            file = File.Open(Application.persistentDataPath + "/savedStars.dat", FileMode.Open);
        }
        else
        {
            file = File.Open("savedStars.dat", FileMode.Open);
        }
            
        StarManagement.starList = (List<Star>)formatter.Deserialize(file);
        file.Close();
    }

}

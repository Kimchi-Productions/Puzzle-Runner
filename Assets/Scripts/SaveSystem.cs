using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSystem
{
    public static void SaveStar()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream("savedStars.dat", FileMode.Create);
        formatter.Serialize(stream, StarManagement.starList);
        stream.Close();
    }

    public static void LoadStar()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open("savedStars.dat", FileMode.Open);
        StarManagement.starList = (List<Star>)formatter.Deserialize(file);
        file.Close();
    }

}

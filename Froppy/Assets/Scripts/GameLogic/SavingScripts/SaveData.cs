using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Data.Sqlite;
/*using System.IO;
using System.Runtime.Serialization.Formatters.Binary;*/

public class SaveData
{
    




    /*public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.kt";

        FileStream fileStream = new FileStream(path,FileMode.Create);
        PlayerData playerData = new PlayerData(player);

        formatter.Serialize(fileStream, path);
        fileStream.Close();
    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.kt";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
            return data;
        }
        else
        {
            Debug.LogError("No Data file on path" + path);
            return null;
        }
       
    }*/
}


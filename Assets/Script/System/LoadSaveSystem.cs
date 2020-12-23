using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Script.Store_Data;
using System.Collections.Generic;
using System;
[System.Serializable]
public static class LoadSaveSystem
{
    public static void SavePlayer()
    {
        string path = Application.persistentDataPath + "/player";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        Data data = new Data();
        formatter.Serialize(stream, data);
        stream.Close(); 
        // System.Runtime.Serialization.Formatters.Binary;
        // Chỉ lấy những thành viên data được mark là Serializeble;
        // Nên class Playerdata Phải được System.Serializeble mới được chấp nhận

        //[System.Serializable]
        //public class PlayerData


    }

    public static Data LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = (Data)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}

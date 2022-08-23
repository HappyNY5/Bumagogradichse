using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.xer";
        
        FileStream stream = new FileStream(path,FileMode.Create);
        
        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
       
        stream.Close();
        
    }

    public static void SaveCity(CityController city)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path2 = Application.persistentDataPath + "/city.xer";
       
        FileStream stream2 = new FileStream(path2,FileMode.Create);
        
        CityData data2 = new CityData(city);
                
        formatter.Serialize(stream2, data2);
        
        stream2.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.xer";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            
            stream.Close();
        
            return data;

        }else{
            Debug.Log("Save PLAYER file not found!");
            return null;
        }

    }

    public static CityData LoadCity()
    {
        
        string path2 = Application.persistentDataPath + "/city.xer";

        if(File.Exists(path2))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream2 = new FileStream(path2,FileMode.Open);
            
            CityData data2 = formatter.Deserialize(stream2) as CityData;
            
            stream2.Close();

            return data2;

        }else{
            Debug.Log("Save CITY file not found!");
            return null;
        }

    }
}

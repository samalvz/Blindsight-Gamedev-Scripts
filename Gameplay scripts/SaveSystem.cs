using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Saved to: " + path);             // debug print
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.dataPath + "/player.save";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            Debug.Log("Loading player save...");
            return data;
        }
        else
        {
            Debug.Log("Unable to Load...(SaveSystem.cs)");
            Debug.LogError("No save in " + path);
            return null;
        }
    }
    
}

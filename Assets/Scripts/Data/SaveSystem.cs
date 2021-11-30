using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

static public class SaveSystem
{
    public static void SavePlayer(Player player, GameController gameController){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player"+ gameController.GetLevel().ToString() + ".dt";

        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data(player, gameController);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data LoadData(int levelId){
        string path = Application.persistentDataPath + "/player" + levelId.ToString() +".dt";

        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;

            stream.Close();

            return data;
        }
        else{
            Debug.LogError("Save file not found");
            return null;
        }
    }
    public static void DeleteProgress(int numberOfLevels){
        for(int i = 0; i < numberOfLevels; i++){
            string path = Application.persistentDataPath + "/player" + i.ToString() +".dt";
            if(File.Exists(path)){ File.Delete(path); }
        }
    }
}

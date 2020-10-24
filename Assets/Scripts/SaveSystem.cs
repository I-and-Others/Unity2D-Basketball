using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData (InGameOptions sets){
    	BinaryFormatter formatter = new BinaryFormatter();
    	string path = Application.persistentDataPath + "/gamedata.iandothers";
    	FileStream fs = new FileStream(path, FileMode.Create);

    	GameData data = new GameData(sets);

    	formatter.Serialize(fs, data);
    	fs.Close();
    }

    public static GameData LoadSettings(){
    	string path = Application.persistentDataPath + "/gamedata.iandothers";
    	if(File.Exists(path)){
    		BinaryFormatter formatter = new BinaryFormatter();
    		FileStream fs = new FileStream(path, FileMode.Open);

    		GameData data = formatter.Deserialize(fs) as GameData;
    		fs.Close();
    		return data;
    	}else{
    		Debug.Log(path + " yolunda kayıt bulunamadı. FeelsBadMan...");
    		return null;
    	}

    }
}

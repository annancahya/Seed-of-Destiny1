using UnityEngine;

[System.Serializable]
public class SaveData {
    public int lives;
    public Vector3 playerPosition;
    public int currentLevel;
}

public class SaveSystem : MonoBehaviour {
    public static void SaveGame(SaveData data) {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SaveData", json);
        PlayerPrefs.Save();
    }

    public static SaveData LoadGame() {
        if (PlayerPrefs.HasKey("SaveData")) {
            string json = PlayerPrefs.GetString("SaveData");
            return JsonUtility.FromJson<SaveData>(json);
        }
        return null;
    }

    public static void DeleteSave() {
        PlayerPrefs.DeleteKey("SaveData");
    }
}

using UnityEngine;
using System.IO;

public class mMainManager : MonoBehaviour
{
    public static mMainManager Instance;

    public string CurrentPlayerName; 
    public int CurrentScore; 
    public string BestPlayerName; 
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }

    [System.Serializable]
    class SaveData
    {
        public string CurrentPlayerName;
        public string BestPlayerName;
        public int BestScore;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();

        data.CurrentPlayerName = CurrentPlayerName;
        data.BestPlayerName = BestPlayerName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        Debug.Log(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            CurrentPlayerName = data.CurrentPlayerName;
            BestPlayerName = data.BestPlayerName;
            BestScore = data.BestScore;
        }
    }

}

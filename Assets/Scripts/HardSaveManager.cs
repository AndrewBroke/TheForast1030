using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class SaveData
{
    public Vector3 position;
    public float rotation;
    public int health;
    public int coins;
}

public class HardSaveManager : MonoBehaviour
{
    InputAction saveAction;
    SaveData data = new SaveData();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveAction = InputSystem.actions.FindAction("Save");
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            // Загружаем из файла
            string json = File.ReadAllText(path);
            // Превращаем текст в переменные
            data = JsonUtility.FromJson<SaveData>(json);

            transform.position = data.position;
            transform.rotation = Quaternion.Euler(0, data.rotation, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (saveAction.WasPressedThisFrame())
        {
            data.position = transform.position;
            data.rotation = transform.rotation.eulerAngles.y;
            data.health = 60;
            data.coins = 123;

            string json = JsonUtility.ToJson(data, true);
            string path = Application.persistentDataPath + "/savedata.json";
            print(path);
            File.WriteAllText(path, json);
        }
    }
}

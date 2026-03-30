using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSaveManager : MonoBehaviour
{
    InputAction saveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveAction = InputSystem.actions.FindAction("Save");

        if(PlayerPrefs.HasKey("PosX"))
        {
            // Загрузить переменные
            float x = PlayerPrefs.GetFloat("PosX", 0);
            float y = PlayerPrefs.GetFloat("PosY", 0);
            float z = PlayerPrefs.GetFloat("PosZ", 0);
            float rot = PlayerPrefs.GetFloat("Rot", 0);

            transform.position = new Vector3(x, y, z);
            transform.rotation = Quaternion.Euler(0, rot, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(saveAction.WasPressedThisFrame())
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            float rot = transform.rotation.eulerAngles.y;

            // Сохранение
            PlayerPrefs.SetFloat("PosX", x);
            PlayerPrefs.SetFloat("PosY", y);
            PlayerPrefs.SetFloat("PosZ", z);
            PlayerPrefs.SetFloat("Rot", rot);
        }
    }
}

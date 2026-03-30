using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public int capsules = 0;
    public int cylinders = 0;
    public int cubes = 0;
    [SerializeField] Animator invAnimator;
    [SerializeField] Text capsuleText;
    [SerializeField] Text cylinderText;
    [SerializeField] Text cubeText;

    // Переменная для Action Inventory
    InputAction invAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Найти Action Inventory
        invAction = InputSystem.actions.FindAction("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        // Если нажали в текущем кадре Action Inventory - Активировать триггер use
        if(invAction.WasPressedThisFrame())
        {
            invAnimator.SetTrigger("Use");
        }
    }
    public void AddObject(string name)
    {
        if(name == "capsule")
        {
            capsules++;
            capsuleText.text = "Capsules: " + capsules;
        }
        else if (name == "cylinder")
        {
            cylinders++;
            cylinderText.text = "Cylinders: " + cylinders;
        }
        else if (name == "cube")
        {
            cubes++;
            cubeText.text = "Cubes: " + cubes;
        }

        print("Capsules: " +  capsules + ". Cylynders: " + cylinders + ". Cubes: " + cubes);
    }

    

    
}

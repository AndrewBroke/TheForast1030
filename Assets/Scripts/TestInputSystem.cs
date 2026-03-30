using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputSystem : MonoBehaviour
{

    // 1. Создание action глобальных переменных
    InputAction moveAction;
    InputAction jumpAction;
    InputAction interactAction;
    InputAction sprintAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 2. Получение Action. В Start()
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        interactAction = InputSystem.actions.FindAction("Interact");
        sprintAction = InputSystem.actions.FindAction("Sprint");
    }

    // Update is called once per frame
    void Update()
    {
        // 3. Использование. В Update()

        // Вектор направления движения
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        print(moveValue);

        // Однократное нажатие
        if(jumpAction.WasPressedThisFrame())
        {
            print("Прыжок");
        }
        // Однократное нажатие
        if (interactAction.WasPressedThisFrame())
        {
            print("Ваимодействие");
        }

        // Зажатие
        if (sprintAction.IsPressed()) 
        {
            print("Увеличить скорость");
        }
    }
}

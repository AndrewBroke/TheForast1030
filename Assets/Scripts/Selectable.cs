using UnityEngine;
using UnityEngine.InputSystem;

public class Selectable : MonoBehaviour
{
    [SerializeField] Pickup pickup;
    [SerializeField] Inventory inventory;
    [SerializeField] string objName;
    Outline outline;

    InputAction interactAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        outline = GetComponent<Outline>();
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        if(pickup.selectedObject == gameObject && outline.enabled == false)
        {
            outline.enabled = true;
        }
        else if (pickup.selectedObject != gameObject && outline.enabled == true)
        {
            outline.enabled = false;
        }

        // Если нажали на кнопку Е и скрипт outline включен
        // удалить объект

        if (interactAction.WasPressedThisFrame() && outline.enabled == true)
        {
            Destroy(gameObject);
            inventory.AddObject(objName);
        }
    }
}

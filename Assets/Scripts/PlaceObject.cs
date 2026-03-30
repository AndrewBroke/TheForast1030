using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlaceObject : MonoBehaviour
{
    [SerializeField] GameObject cubeObject;
    [SerializeField] GameObject capsuleObject;
    [SerializeField] GameObject cylinderObject;
    [SerializeField] LayerMask layerMask;

    int currentObject = -1;
    InputAction selectSlotAction;
    InputAction attackAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectSlotAction = InputSystem.actions.FindAction("SelectSlot");
        attackAction = InputSystem.actions.FindAction("Attack");
        selectSlotAction.performed += OnSelectSlot;
    }

    void OnSelectSlot(InputAction.CallbackContext context)
    {
        print(context.control.name); // 1, 2 ,3
        if(context.control.name == "1")
        {
            cubeObject.SetActive(true);
            capsuleObject.SetActive(false);
            cylinderObject.SetActive(false);
        }
        else if (context.control.name == "2")
        {
            cubeObject.SetActive(false);
            capsuleObject.SetActive(true);
            cylinderObject.SetActive(false);
        }
        else if (context.control.name == "3")
        {
            cubeObject.SetActive(false);
            capsuleObject.SetActive(false);
            cylinderObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10, layerMask);

        print(hit.collider);
        if (hit.collider != null)
        {
            cubeObject.transform.position = hit.point;
            capsuleObject.transform.position = hit.point;
            cylinderObject.transform.position = hit.point;
        }

        if(attackAction.WasPressedThisFrame())
        {
            if(cubeObject.activeSelf)
            {
                GameObject temp = Instantiate(cubeObject, cubeObject.transform.position, cubeObject.transform.rotation);
            }
            else if (capsuleObject.activeSelf)
            {
                Instantiate(capsuleObject, capsuleObject.transform.position, capsuleObject.transform.rotation);
            }
            else if(cylinderObject.activeSelf)
            {
                Instantiate(cylinderObject, cylinderObject.transform.position, cylinderObject.transform.rotation);
            }
        }
    }
}

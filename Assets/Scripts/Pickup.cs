using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] float rayDistance = 2.0f;
    [SerializeField] LayerMask mask;
    public GameObject selectedObject;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        /*
         Raycast(начало, направление, переменная для результата, дистанция, маска слоя)
         */
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayDistance, mask);

        print(hit.collider);
        if(hit.collider != null)
        {
            if(hit.collider.CompareTag("Selectable"))
            {
                selectedObject = hit.collider.gameObject;
            }
            else
            {
                selectedObject = null;
            }
        }
        else
        {
            selectedObject = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rayDistance);
    }
}

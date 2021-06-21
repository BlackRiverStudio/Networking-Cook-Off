using UnityEngine;

public class RaycastCamInteract : MonoBehaviour
{
    private Transform dragObject;
    private Vector3 offset;

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, transform.right * 50, Color.blue);


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            LayerMask layer = LayerMask.GetMask("Interact");
            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
            {
                dragObject = hit.transform;
                offset = hit.transform.position - ray.origin;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragObject = null;
        }

        if (dragObject)
        {
            dragObject.position = new Vector3(ray.origin.x + offset.x, dragObject.position.y, ray.origin.z + offset.z);
        }
    }
}
using UnityEngine;

public class ItemInteractions : MonoBehaviour
{
    [SerializeField] private Transform pickupPoint;
    
    void Update() {
        Interact();
    }

    public void Interact() {
        Ray ray = new Ray(transform.position, -transform.right * 50);
        RaycastHit hitInfo;

        Debug.DrawRay(transform.position, -transform.right * 50, Color.blue);

        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            //Grab food from fridge
            if (hitInfo.collider.TryGetComponent(out FoodItem item))
            {
                if (item != null && Input.GetMouseButton(0))
                {
                    item.transform.position = pickupPoint.position;
                }
            }
        }
    }
}
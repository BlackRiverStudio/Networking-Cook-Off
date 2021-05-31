using UnityEngine;

public class ItemInteractions : MonoBehaviour
{
    private const string itemLayer = "Interactable";
    private const string bacon = "Bacon";
    [SerializeField] private Transform hand;
    
    void Update() {
        Interact();
    }

    public void Interact() {
        Ray ray = new Ray(transform.position + transform.forward * 0.5f, transform.forward);
        RaycastHit hitInfo;
        int layerMask = LayerMask.NameToLayer(itemLayer);

        //Moving binary 1 over to the left, method 1 if dont want to search for the name of layer
        //Actually turning it into a layer and not a value
        layerMask = 1 << layerMask;

        Debug.DrawRay(transform.position, transform.forward * 50, Color.magenta);
        //If Ray hits something
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
        {
            //Grab food from fridge
            if (hitInfo.collider.gameObject.name.Equals(bacon))
            {
                SetFoodParent(hitInfo.collider.gameObject, hand);
                //Debug that we hit a food    
                Debug.Log($"Got {gameObject.name} out of the fridge!");
            }
        }
    }

    public void SetFoodParent(GameObject child, Transform newParent) {
        child.transform.SetParent(newParent);
    }
}
using System;
using UnityEngine;

public class PickUpFood : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mouseZCoordinates;
    public Camera mainCam;
    public Transform hand;

    private void Start() {
        gameObject.GetComponent<FoodItem>();
    }

    private void OnMouseDown() { 
    mouseZCoordinates = mainCam.WorldToScreenPoint(gameObject.transform.position).z;
    mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag() {
        transform.position = GetMouseWorldPos() + mouseOffset;
        transform.parent = hand;
    }

    private Vector3 GetMouseWorldPos() {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mouseZCoordinates;
        return mainCam.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseUp() {
        //Let go of object
        transform.parent = null;
    }
}

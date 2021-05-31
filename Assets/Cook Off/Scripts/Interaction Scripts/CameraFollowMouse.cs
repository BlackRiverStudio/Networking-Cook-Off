using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    [SerializeField, Tooltip("X Position Sensitivity")]
    private float horizontalSpeed;

    [SerializeField, Tooltip("Y Position Sensitivity")]
    private float verticalSpeed;

    [Tooltip("Rotation on Y axis")] private float mouseY;
    [Tooltip("Rotation on X axis")] private float mouseX;
    private float xClamp = 0.0f;

    public Transform playerBody;
    
    private void Start() {
        horizontalSpeed = 2f;
        verticalSpeed = 2f;
    }

    // Update is called once per frame
    void Update() {
        FollowMouseInput();
    }


    /// <summary>
    /// Makes the camera follow the mouse position.
    /// </summary>
    public void FollowMouseInput() {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        float xRotation = mouseX * horizontalSpeed / 2;
        float yRotation = mouseY * verticalSpeed / 2;

        xClamp -= yRotation;

        Vector3 targetRotation = transform.rotation.eulerAngles;
        targetRotation.x -= yRotation;
        targetRotation.z = 0;
        targetRotation.y += xRotation;
        
        //Player
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;
        targetRotBody.y += xRotation;
        
        
        if (xClamp > 90)
        {
            xClamp = 90;
            targetRotation.x = 90;
        }
        else if (xClamp < -90)
        {
            targetRotation.x = -90;
            targetRotation.x = 270;
        }
        
        transform.rotation = Quaternion.Euler(targetRotation);
        playerBody.rotation = Quaternion.Euler(targetRotBody);
    }
}

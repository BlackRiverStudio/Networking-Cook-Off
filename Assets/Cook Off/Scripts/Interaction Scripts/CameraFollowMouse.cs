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
        Cursor.lockState = CursorLockMode.Confined; //Confine cursor to game window
    }


    /// <summary>
    /// Makes the camera follow the mouse position.
    /// </summary>
    public void FollowMouseInput() {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        //Mouse speed
        float xRotation = mouseX * horizontalSpeed / 2;
        float yRotation = mouseY * verticalSpeed / 2;

        //Clamp on x and y rotation
        xClamp -= yRotation;

        //Camera rotation
        Vector3 targetRotation = transform.rotation.eulerAngles;
        targetRotation.x -= yRotation;
        targetRotation.z = 0;
        targetRotation.y += xRotation;
        
        //Player rotation
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;
        targetRotBody.y += xRotation;
        
        //Clamp rotation
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

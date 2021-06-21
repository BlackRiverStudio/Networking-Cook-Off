using UnityEngine;

namespace CookOff
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;

        private void Update() {
            //Move player only side to side on Z Axis 
            float zDirection = Input.GetAxis("Horizontal");

            Vector3 moveDirection = new Vector3(0f, 0f, zDirection);

            transform.position += moveDirection * speed;
        }
    }
}
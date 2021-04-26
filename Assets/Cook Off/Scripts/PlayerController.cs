using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace CookOff
{
    public class PlayerController : MonoBehaviour
    {
        PlayerInput input;

        [SerializeField]InputActionReference moveAction;

        private void Start()
        {
            moveAction.action.ReadValue<Vector2>();
        }

        private void Update()
        {
            transform.position += transform.right * Time.deltaTime * moveAction.action.ReadValue<Vector2>().x;
            transform.position += transform.forward * Time.deltaTime * moveAction.action.ReadValue<Vector2>().y;
        }
    }
}
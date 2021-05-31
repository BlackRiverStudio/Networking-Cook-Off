using UnityEngine;
using InputActionRef = UnityEngine.InputSystem.InputActionReference;
namespace CookOff
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputActionRef moveAction;
        private void Start() => moveAction.action.ReadValue<Vector2>();
        private void Update()
        {
            transform.position += transform.right * Time.deltaTime * moveAction.action.ReadValue<Vector2>().x;
            transform.position += transform.forward * Time.deltaTime * moveAction.action.ReadValue<Vector2>().y;
        }
    }
}
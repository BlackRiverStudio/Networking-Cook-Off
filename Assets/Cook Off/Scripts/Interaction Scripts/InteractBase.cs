using UnityEngine;

public class InteractBase : MonoBehaviour
{
    private Animator animator;

    private void Start() {
        animator = GetComponentInParent<Animator>();
        animator.Play("F_Idle");
    }

    private void OnMouseEnter() {
        animator.Play("F_Open");
    }

    private void OnMouseExit() {
        if (Input.GetKey(KeyCode.C))
        {
            animator.Play("F_Close");
        }
    }
}
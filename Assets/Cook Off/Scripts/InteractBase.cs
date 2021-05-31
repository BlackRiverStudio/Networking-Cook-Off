using UnityEngine;

public class InteractBase : MonoBehaviour
{
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        animator.Play("F_Idle");
    }

    private void OnMouseEnter() {
        animator.Play("F_Open");
    }

    private void OnMouseExit() {
        animator.Play("F_Close");
    }
}
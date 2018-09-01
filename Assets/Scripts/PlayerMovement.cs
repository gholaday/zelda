using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1;

    Rigidbody2D rb;
    Vector3 change;
    Animator animator;
    bool canMove = true;

    DialogManager dialogManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dialogManager = FindObjectOfType<DialogManager>();
        canMove = true;
    }

    void Update()
    {
        canMove = !dialogManager.IsDialogWindowOpen;
        change = Vector2.zero;

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (change != Vector3.zero && canMove)
        {
            MoveCharacter();
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void MoveCharacter()
    {
        rb.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);

        animator.SetFloat("moveX", change.x);
        animator.SetFloat("moveY", change.y);
        animator.SetBool("isMoving", true);
    }

}

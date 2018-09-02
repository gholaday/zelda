using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1;
    public PlayerState CurrentState;

    public enum PlayerState
    {
        Walking,
        Attacking
    }

    Rigidbody2D rb;
    Vector3 change;
    Animator animator;
    bool canMove = true;
    bool isTeleporting = false;

    DialogManager dialogManager;
    CameraMovement cameraMovement;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dialogManager = FindObjectOfType<DialogManager>();
        cameraMovement = FindObjectOfType<CameraMovement>();
        canMove = true;
        CurrentState = PlayerState.Walking;
    }

    void Update()
    {
        canMove = !dialogManager.IsDialogWindowOpen && !isTeleporting;
        change = Vector2.zero;

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Attack") && CurrentState != PlayerState.Attacking)
        {
            StartCoroutine(Attack());
        }

        if (CurrentState == PlayerState.Walking)
        {
            MoveCharacter();
        }
    }

    IEnumerator Attack()
    {
        animator.SetBool("isAttacking", true);
        CurrentState = PlayerState.Attacking;
        yield return null;

        animator.SetBool("isAttacking", false);
        yield return StartCoroutine(WaitFor.Frames(19));

        CurrentState = PlayerState.Walking;
    }

    void MoveCharacter()
    {
        if (change != Vector3.zero && canMove)
        {
            rb.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);

            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    public void TeleportCharacter(Vector3 telePos)
    {
        StartCoroutine("StartTeleportTransition", telePos);
    }

    IEnumerator StartTeleportTransition(Vector3 telePos)
    {
        isTeleporting = true;
        FindObjectOfType<ScreenTransitions>().FadeToBlackToClear();

        yield return new WaitForSeconds(.5f);

        transform.position = telePos;
        cameraMovement.SnapToPlayer();

        yield return new WaitForSeconds(1f);
        isTeleporting = false;
    }

}

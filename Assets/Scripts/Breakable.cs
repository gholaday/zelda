using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Break()
    {
        animator.SetTrigger("destroy");

        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

    }
}

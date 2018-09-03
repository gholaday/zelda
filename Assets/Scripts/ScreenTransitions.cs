using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransitions : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToBlackToClear()
    {
        anim.SetTrigger("fadeToBlackToClear");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransitions : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        transform.GetComponent<Renderer>().sortingLayerName = "Top";
        anim = GetComponent<Animator>();
    }

    public void FadeToBlackToClear()
    {
        anim.SetTrigger("fadeToBlackToClear");
    }
}

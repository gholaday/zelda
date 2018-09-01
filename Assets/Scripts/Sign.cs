using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour, IInteractable
{

    public string[] DialogText;

    DialogManager dialogManger;

    void Awake()
    {
        dialogManger = FindObjectOfType<DialogManager>();
    }

    public void DisplayDialog()
    {
        dialogManger.ShowDialogWindow(DialogText);
    }
}

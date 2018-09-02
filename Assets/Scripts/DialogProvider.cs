using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogProvider : MonoBehaviour
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

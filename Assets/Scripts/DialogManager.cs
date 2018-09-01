using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public GameObject DialogBox;
    public TextMeshProUGUI dialogText;
    public bool IsDialogWindowOpen = false;

    bool canInteract = false;
    int currentDialogIndex = 0;
    string[] dialogs;

    void Awake()
    {
    }

    void Update()
    {
        if (IsDialogWindowOpen && Input.GetButtonDown("Interact") && canInteract)
        {
            CycleDialog();
        }
    }

    public void ShowDialogWindow(string[] text)
    {
        dialogs = text;
        IsDialogWindowOpen = true;
        DialogBox.SetActive(true);
        Invoke("SetCanInteract", .1f);
        CycleDialog();
    }

    public void HideDialogWindow()
    {
        IsDialogWindowOpen = false;
        canInteract = false;
        currentDialogIndex = 0;
        DialogBox.SetActive(false);
    }

    void CycleDialog()
    {
        if (currentDialogIndex >= dialogs.Length)
        {
            HideDialogWindow();
            return;
        }

        dialogText.text = dialogs[currentDialogIndex];
        currentDialogIndex++;
    }

    void SetCanInteract()
    {
        canInteract = true;
    }

}

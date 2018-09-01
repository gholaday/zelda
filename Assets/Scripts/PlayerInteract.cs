using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    RoomManager roomManager;
    DialogManager dialogManager;
    void Awake()
    {
        roomManager = FindObjectOfType<RoomManager>();
        dialogManager = FindObjectOfType<DialogManager>();
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Room")
        {
            InteractRoom(other);
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Sign")
        {
            if (!dialogManager.IsDialogWindowOpen && Input.GetButtonDown("Interact"))
            {
                InteractSign(other);
            }

        }
    }

    void InteractRoom(Collider2D other)
    {
        roomManager.SetCurrentRoom(other.GetComponent<Room>());
    }

    void InteractSign(Collider2D other)
    {
        Sign sign = other.GetComponent<Sign>();

        if (sign != null)
        {
            sign.DisplayDialog();
        }

    }
}

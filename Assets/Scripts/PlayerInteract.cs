using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    RoomManager roomManager;
    DialogManager dialogManager;
    PlayerMovement playerMovement;

    void Awake()
    {
        roomManager = FindObjectOfType<RoomManager>();
        dialogManager = FindObjectOfType<DialogManager>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Teleporter")
        {
            playerMovement.TeleportCharacter(other.GetComponent<Teleporter>().PlayerSpawn.position);
        }

        if (other.tag == "Room")
        {
            InteractRoom(other);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "DialogProvider")
        {
            if (!dialogManager.IsDialogWindowOpen && Input.GetButtonDown("Interact"))
            {
                InteractDialogProvider(other);
            }

        }
    }

    void InteractRoom(Collider2D other)
    {
        roomManager.SetCurrentRoom(other.GetComponent<Room>());
    }

    void InteractDialogProvider(Collider2D other)
    {
        DialogProvider dialogProvider = other.GetComponent<DialogProvider>();

        if (dialogProvider != null)
        {
            dialogProvider.DisplayDialog();
        }

    }
}

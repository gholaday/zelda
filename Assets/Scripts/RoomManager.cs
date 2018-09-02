using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public Room CurrentRoom;
    public Animator UIAnimator;
    public Text RoomNameDisplayText;
    public void SetCurrentRoom(Room newRoom)
    {
        if (newRoom != CurrentRoom)
        {
            CurrentRoom = newRoom;

            float timeToDisplay = newRoom.IsDisconnected ? 2f : 0;

            Invoke("DisplayRoomName", timeToDisplay);
        }
    }

    public void DisplayRoomName()
    {
        if (RoomNameDisplayText != null)
        {
            RoomNameDisplayText.text = CurrentRoom.RoomName;
        }

        if (UIAnimator != null)
        {
            UIAnimator.SetTrigger("displayRoomName");
        }
    }

}
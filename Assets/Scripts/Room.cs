using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string RoomName;
    public BoxCollider2D RoomCollider;
    public bool IsDisconnected;

    public Bounds GetRoomBounds()
    {
        return RoomCollider.bounds;
    }
}
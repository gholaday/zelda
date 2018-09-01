using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{

    public Transform PlayerSpawn;
    public MeshRenderer NewRoomBounds;
    [SerializeField]
    public Room Room;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<ScreenTransitions>().FadeToBlackToClear();
            other.transform.position = PlayerSpawn.position;
            //Camera.main.GetComponent<CameraMovement>().mapBounds = NewRoomBounds;

            // FindObjectOfType<RoomManager>().DisplayRoomName(Room);
        }
    }
}

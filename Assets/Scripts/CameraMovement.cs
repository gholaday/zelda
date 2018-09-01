using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float smoothing;

    float cameraHalfWidth;
    Camera cam;
    RoomManager roomManager;
    Bounds mapBounds;
    float targetCamSize = 6;

    void Awake()
    {
        cam = GetComponent<Camera>();
        roomManager = FindObjectOfType<RoomManager>();
    }

    void FixedUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, -10);

            if (roomManager.CurrentRoom != null)
            {
                mapBounds = roomManager.CurrentRoom.GetRoomBounds();

                targetCamSize = mapBounds.size.x / 3.0f;
                targetCamSize = Mathf.Clamp(targetCamSize, 3, 6);

                cameraHalfWidth = cam.orthographicSize * ((float)Screen.width / Screen.height);

                targetPos.x = Mathf.Clamp(targetPos.x, mapBounds.min.x + cameraHalfWidth, mapBounds.max.x - cameraHalfWidth);
                targetPos.y = Mathf.Clamp(targetPos.y, mapBounds.min.y + cam.orthographicSize, mapBounds.max.y - cam.orthographicSize);
            }

            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetCamSize, smoothing * 2 * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
        }
    }
}

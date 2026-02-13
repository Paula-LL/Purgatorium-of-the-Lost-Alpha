using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(-10f, 10f, -10f);
    public float smoothSpeed = 5f;

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;  

        transform.LookAt(player);
    }
}

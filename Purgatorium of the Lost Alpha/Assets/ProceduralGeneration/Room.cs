using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int witdh;
    public int heigth;
    public int anchura;
    public int X;
    public int Z;
    public GameObject roomFloor;

    private void Start()
    {
        if (RoomController.Instance == null)
        {
            Debug.Log("Escena equivocada");
        }
        roomFloor.transform.localScale = new Vector3(witdh, anchura, heigth);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(witdh, anchura, heigth));
    }
    public Vector3 getRoomCenter()
    {
        return new Vector3(X * witdh, transform.position.y, Z * heigth);
    }
}

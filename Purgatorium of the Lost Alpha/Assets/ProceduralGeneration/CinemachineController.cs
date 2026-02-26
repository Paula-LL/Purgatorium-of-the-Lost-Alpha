using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineController : MonoBehaviour
{
    public List <GameObject> roomList = new List <GameObject> ();
    public GameObject salaActual;
    public GameObject player;
   

    private void Start()
    {
        roomList = DungeonGenerator.s._dungeonRoomInstances;
        salaActual = roomList[0];
    }

   
}

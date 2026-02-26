using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineController : MonoBehaviour
{
    public List <GameObject> roomList = new List <GameObject> ();
    public Collider[] roomColliders; 
    public GameObject salaActual;
    public GameObject player;
    public bool playerDetectado = false;
    public CinemachineVirtualCamera virtualCameraAcutal;
    public int incrementalPriority = 12;
    public DungeonGenerator dungeonGenerator;
   

    private void Start()
    {
        foreach (GameObject room in dungeonGenerator._dungeonRoomInstances)
        {
            roomList.Add (room);
        }
        salaActual = roomList[0];
        establecerCameraActualStart();

    }
    public void establecerCameraActualStart()
    {
        virtualCameraAcutal = salaActual.GetComponentInChildren<CinemachineVirtualCamera>();
        virtualCameraAcutal.Priority = incrementalPriority + 1;
    }
    private void Update()
    {
        foreach (GameObject room in roomList)
        {
            roomColliders = room.GetComponentsInChildren<Collider>();
            foreach (Collider collider in roomColliders)
            {
                if (collider.isTrigger)
                {
                    OnTriggerEnter(collider);
                }
                
            }
            if (playerDetectado)
            {
                salaActual = room;
                changeVirtualCamera(room);
            }
            
        }
        
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            playerDetectado = true;
        }
    }
    public void changeVirtualCamera(GameObject room)
    {
        virtualCameraAcutal = room.GetComponentInChildren<CinemachineVirtualCamera> ();
        virtualCameraAcutal.Priority = incrementalPriority + 1;
    }
}

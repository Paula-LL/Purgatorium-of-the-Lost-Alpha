using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DungeonGenerator;

public class CinemachineControlller : MonoBehaviour
{
    public GameObject Player;
    private CinemachineVirtualCamera camaraActual;
    public GameObject [] roomPrefabs;
    private GameObject initialRoom;
   
    private void Start()
    {
            
            
    }
    private void Update()
    {
        foreach (GameObject room in roomPrefabs)
        {
            if (Player.transform.position == room.transform.position)
            {
                camaraActual = room.GetComponentInChildren<CinemachineVirtualCamera>();
                camaraActual.Priority = 100;
            }
        }
    }
}

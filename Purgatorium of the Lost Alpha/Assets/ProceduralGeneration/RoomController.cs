using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo
{
    public string nameRoom;
    public int X;
    public int Z;
    private float wallsWidth = 4;
    private float wallsHeight = 10;
}
public class RoomController : MonoBehaviour
{
    [Header("Singleton")]
    public static RoomController Instance;

    [Header("RoomData")]
    private string levelName;
    RoomInfo currentRoomData;
    Queue<RoomInfo> loadRoomQueque = new Queue<RoomInfo>();
    public List<Room> loadedRooms = new List<Room>();
    private bool isLoadingRoom;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    public void loadRoom (string roomName, int x, int z)
    {
        RoomInfo newRoomData = new RoomInfo();
        newRoomData.nameRoom = roomName;
        newRoomData.X = x;
        newRoomData.Z = z;

        loadRoomQueque.Enqueue(newRoomData);    
    }
    IEnumerator LoadRoomRoutine(RoomInfo info)
    {
        string roomName = levelName + info.nameRoom;
        yield return null;
    }
    public bool doesRoomExists (int X,  int Z)
    {
        return loadedRooms.Find(item => item.X == X && item.Z == Z ) != null; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private string levelName = "IraLuguria";
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
    private void Start()
    {
        LoadRoom("Start", 0, 0);
        LoadRoom("Start", 1, 0);
        LoadRoom("Start", -1, 0);
        LoadRoom("Start", 0, 1);
        LoadRoom("Start", 0, -1);
    }
    private void Update()
    {
        UpdateRoomQueque();
    }
    public void UpdateRoomQueque()
    {
        if (isLoadingRoom)
        {
            return;
        }
        if (loadRoomQueque.Count == 0)
        {
            return;
        }

        currentRoomData = loadRoomQueque.Dequeue();
        isLoadingRoom = true;   

        StartCoroutine(LoadRoomRoutine(currentRoomData));
    }
    public void LoadRoom (string roomName, int x, int z)
    {
        if (doesRoomExists(x, z))
        {
            return;
        }
        RoomInfo newRoomData = new RoomInfo();
        newRoomData.nameRoom = roomName;
        newRoomData.X = x;
        newRoomData.Z = z;

        loadRoomQueque.Enqueue(newRoomData);    
    }
    IEnumerator LoadRoomRoutine(RoomInfo info)
    {
        string roomName = levelName;

        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while (!loadRoom.isDone == false)
        {
            yield return null;
        }
        
    }
    public void RegisterRoom(Room room)
    {
        room.transform.position = new Vector3(currentRoomData.X = room.witdh, 0, currentRoomData.Z = room.heigth);
        room.X = currentRoomData.X;
        room.Z = currentRoomData.Z;
        room.name = levelName + " " + currentRoomData.nameRoom + " ("+ room.X + ", " + room.Z+ ")";
        room.transform.parent = transform;

        isLoadingRoom = false;
        loadedRooms.Add(room);
    }
    public bool doesRoomExists (int X,  int Z)
    {
        return loadedRooms.Find(item => item.X == X && item.Z == Z ) != null; 
    }
}

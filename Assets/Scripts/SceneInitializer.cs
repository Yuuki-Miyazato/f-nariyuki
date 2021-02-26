using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{

    public const int MAP_SIZE_X = 40;
    public const int MAP_SIZE_Y = 40;

    public const int MAX_ROOM_NUMBER = 10;

    private GameObject _player;
    private GameObject floorPrefab;
    private GameObject wallPrefab;

    private int[,] map;
    void Start()
    {

        GenerateMap();

    }

    private void GenerateMap()
    {
        map = new MapGenerator().GenerateMap(MAP_SIZE_X, MAP_SIZE_Y, MAX_ROOM_NUMBER);

        string log = "";
        for (int y = 0; y < MAP_SIZE_Y; y++)
        {
            for (int x = 0; x < MAP_SIZE_X; x++)
            {
                if(x == 10 && y == 0)
                {
                    _ = map[10, 0] == 2;
                }
                else
                {
                    log += map[x, y] == 0 ? " " : "1";
                }
            }
            log += "\n";
        }
        Debug.Log(log);
        _ = map[10, 0] == 3;

        floorPrefab = Resources.Load("Prefab/Floor") as GameObject;
        wallPrefab = Resources.Load("Prefab/Wall") as GameObject;
        _player = Resources.Load("Prefab/_player") as GameObject;

        var PlayerList = new List<Vector2>();
        var floorList = new List<Vector2>();
        var wallList = new List<Vector2>();

        for (int y = 0; y < MAP_SIZE_Y; y++)
        {
            for (int x = 0; x < MAP_SIZE_X; x++)
            {
                if (map[x, y] == 1)
                {
                    Instantiate(floorPrefab, new Vector2(x, y), new Quaternion());
                }
                else if(map[10,0] == 2){
                    Instantiate(_player, new Vector2(10, 1), new Quaternion());
                }
                else
                {
                    Instantiate(wallPrefab, new Vector2(x, y), new Quaternion());
                }
            }
        }
    }
}

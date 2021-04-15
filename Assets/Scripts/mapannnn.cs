using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapannnn : MonoBehaviour
{
    public GameObject wall;
    public GameObject wall2;
    public GameObject floor;
    public GameObject start;
    public GameObject goal;
    public GameObject goal2;
    public GameObject player;
    public GameObject Key;
    public GameObject enemy;
    public GameObject enemy2;

    public int[,] map = new int[,]
    {
        {-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99 },
        {-99, 98,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,-99 },
        {-99, 99, -1,  0, -1, -1, -1, -1, -1, -1, -1,  0, -1,  0, -1, -1,-99 },
        {-99,  0,  0,  0, -1,  0,  0,  0, -1,  0,  0,  0, -1,  0,  0,  0,-99 },
        {-99,  0, -1, -1, -1,  0, -1,  0, -1,  0, -1,  0, -1,  0, -1,  0,-99 },
        {-99,  0, -1,  0, -1,  0,  0,  3,  0,  0,  0,  0, -1,  0, -1,  0,-99 },
        {-99, -1, -1,  0, -1,  0, -1,  0, -1, -1, -1, -1, -1, -1, -1, -1,-99 },
        {-99,  0, -1,  0,  0,  0, -1,  0,  0,  0,  0,  0,  0,  0,  0,  0,-99 },
        {-99,  0, -1,  0, -1, -1, -1,  0, -1, -1, -1,  0, -1, -1, -1,  0,-99 },
        {-99,  0,  0,  0,  0,  0,  0,  0,  0,  0, -1,  0,  0,  0, -1,  0,-99 },
        {-99, -1, -1,  0, -1, -1, -1, -1, -1,  0, -1,  0, -1,  0, -1,  0,-99 },
        {-99,  0,  0,  0, -1,  0,  0,  0, -1,  0,  0,  0, -1,  0,  0,  0,-99 },
        {-99,  0, -1, -1, -1,  0, -1,  0, -1, -1, -1,  0, -1, -1, -1, -1,-99 },
        {-99,  0, -1,  0,  0,  0, -1,  0,  0,  0,  0,  0,  0,  0,  0,  2,-99 },
        {-99,  0, -1,  0, -1, -1, -1,  0, -1,  0, -1, -1, -1, -1, -1,  0,-99 },
        {-99,  1,  0,  0, -1,  0,  0,  0, -1,  0, -1, 10,  0,  0,  0,  0,-99 },
        {-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99, },
    };

    private void Start()
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == -99)
                {
                    Instantiate(wall2, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -1)
                {
                    Instantiate(wall, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == 0)
                {
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == 1)
                {
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    Instantiate(start, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    GameObject playerobj = Instantiate(player, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    playerobj.transform.parent = transform;
                    playerobj.name = "Player";
                }
                if (map[i, j] == 98)
                {
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    Instantiate(goal2, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == 99)
                {

                    Instantiate(goal, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == 3)
                {
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    GameObject enemyobj = Instantiate(enemy, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    enemyobj.transform.parent = transform;
                    enemyobj.name = "Enemy";
                }
                if (map[i, j] == 2)
                {
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    GameObject enemyobj2 = Instantiate(enemy2, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    enemyobj2.transform.parent = transform;
                    enemyobj2.name = "Enemy3";
                }
                if (map[i, j] == 10)
                {
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    Instantiate(Key, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    GameObject Keyobj = Instantiate(Key, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    Keyobj.transform.parent = transform;
                    Keyobj.name = "Key";
                }
            }
        }
    }
}

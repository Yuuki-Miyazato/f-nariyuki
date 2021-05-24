using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map8 : MonoBehaviour
{
    public GameObject wall;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public GameObject wall5;
    public GameObject wall6;
    public GameObject wall7;
    public GameObject wall8;
    public GameObject wall9;
    public GameObject wall10;
    public GameObject wall11;
    public GameObject wall12;
    public GameObject wall13;

    public GameObject floor;
    public GameObject start;
    public GameObject goal;
    public GameObject goal2;
    public GameObject player;
    public GameObject Key;
    public GameObject enemy;
    public GameObject enemy2;

    public GameObject canvasUI;

   // public float a = 

    public int[,] map = new int[,]
    {
       { -7,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-8 },
       { -5,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-6 },
       { -5,-13,-13,-13,-13,-1,-13,-13,-13,-13,-1,-13,-13,-13,-1,-13,-13,-13,-13,-13,-13,-6 },
       { -5, 0, 0, 0, 0,-1, 0, 0, 0, 0,-1, 0, 0, 0,-13, 3, 0, 0, 0, 0, 2,-6 },
       { -5, 0,-1,-1, 0,-13, 0,-1,-1, 0,-13, 0,-1, 0, 0, 0,-1,-1, 0,-1,10,-6 },
       { -5, 0, 0, 0, 0, 0, 3,-1, 0, 0, 0, 0,-1,-1,-1, 0, 0,-1, 0, 0, 0,-6 },
       { -5, 0,-1,-1,-1, 0,-1,-1, 0,-1,-1,-1, 0, 0, 0,-1, 0,-1, 0,-1,-1,-6 },
       { -5, 0, 0,-1,-1, 0, 0, 0, 0, 0, 3,-1, 0,-1, 0, 0, 0, 0, 0, 0, 3,-6 },      //3は直進型
       { -5,-1, 0, 0, 0,-1, 0,-1,-1,-1, 0, 0, 0,-1, 0,-1, 0,-1,-1,-1, 0,-6 },
       { -5,-1,-1,-1, 0, 0, 0,-1, 0, 0, 0,-1, 0, 0, 0,-1, 3, 0, 0, 0, 0,-6 },
       { -5, 0, 0, 0, 0,-1, 0, 0, 0,-1, 0, 0, 0,-1,-1,-1, 0,-1, 0,-1,-1,-6 },
       { -5, 0,-1,-1, 0, 0, 0,-1,-1,-1, 0,-1, 3, 0,-1, 0, 0,-1, 0, 0,-1,-6 },
       { -5, 0, 0, 0, 3,-1, 0,-1, 0, 0, 0,-1,-1, 0,-1, 0,-1,-1,-1, 0,-1,-6 },
       { -5,-1, 0,-1,-1,-1, 3, 0, 0,-1,-1, 3, 0, 0, 0, 0, 0, 0,-1, 0,-1,-6 },
       { -5,-1, 0, 0, 0,-1,-1, 0,-1, 0, 0, 0,-1, 0,-1,-1,-1, 0, 0, 0, 3,-6 },
       { -5,-1,-1,-1, 0, 0, 0, 0, 0, 3,-1, 0, 0, 0, 0, 3,-1,-1,-1,-1, 0,-6 },
       { -5, 0, 0, 0, 0,-1,-1,-1, 0,-1,-1, 0,-1, 0,-1, 0,-1,-1, 0, 0, 0,-6 },
       { -5, 0,-1,-1,-1, 3, 0, 0, 0, 0, 0, 0,-1, 0, 0, 0, 0, 3, 0,-1,-1,-6 },
       { -5, 0, 0, 0, 0, 0,-1,-1, 0,-1,-1, 0,-1,-1,-1,-1, 0,-1, 0, 0, 0,-6 },
       { -5,-1, 0,-1,-1, 0,-1,-1, 0, 0, 0, 0, 3,-1,-1,-1, 0,-1,-1,-1, 0,-6 },
       { -5, 0, 0,-1, 0, 0,-1,-1, 0,-1, 0,-1, 0, 0, 0,-1, 3, 0, 0, 0, 0,-6 },
       { -5, 0,-1,-1, 0,-1, 0, 0, 0, 3, 0,-1, 0,-1, 0,-1, 0,-1, 0,-1,98,-6 },
       { -5, 1, 0, 0, 0, 0, 0,-1,-1,-1, 0, 0, 0,-1, 0, 0, 0,-1, 0, 0,99,-6 },      //2は巡回型
       { -2,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-3 },
       { -13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13 },
       { -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1 },
       { -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1 },
       { -9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9 },
      };

    private void Start()
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                //壁
                if (map[i, j] == -1)
                {
                    Instantiate(wall, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -2)
                {
                    Instantiate(wall2, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -3)
                {
                    Instantiate(wall3, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -4)
                {
                    Instantiate(wall4, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -5)
                {
                    Instantiate(wall5, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -6)
                {
                    Instantiate(wall6, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -7)
                {
                    Instantiate(wall7, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -8)
                {
                    Instantiate(wall8, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -9)
                {
                    Instantiate(wall9, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -10)
                {
                    Instantiate(wall10, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    Instantiate(wall, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -11)
                {
                    Instantiate(wall11, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    Instantiate(wall, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -12)
                {
                    Instantiate(wall12, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    Instantiate(wall9, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == -13)
                {
                    Instantiate(wall13, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    //Instantiate(wall9, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }


                if (map[i, j] == 0)
                {
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == 1)
                {
                    float a = -i-0.8f;
                    a=a*10;
                    //a= float.Parse(a.ToString("f2"));
                    //float a = 0.8f;
                    
                    Vector2 vec2 = new Vector2(j - 1, (Mathf.Floor(-i-0.8f)/10)); 
                    //float b = 8.22f;

                    //Console.WriteLine((Math.Floor(b * 10)) / 10);
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    Instantiate(start, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    GameObject playerobj = Instantiate(player, new Vector2(j - 1f, Mathf.Floor(a)/10 ), Quaternion.identity);
                    playerobj.transform.parent = transform;
                    playerobj.name = "Player";
                    Debug.Log(a);
                    //Debug.Log(b);
                    //Debug.Log(vec2.y);
                }
                if (map[i, j] == 98)
                {
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    Instantiate(goal2, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == 99)
                {
                    GameObject goalobj = Instantiate(goal, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    goalobj.name = "Goal";
                }
                if (map[i, j] == 3)
                {
                    float a = -i - 0.8f;
                    a = a * 10;
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    GameObject enemyobj = Instantiate(enemy, new Vector2(j - 1, Mathf.Floor(a) / 10), Quaternion.identity);
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
                    //Instantiate(Key, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    GameObject Keyobj = Instantiate(Key, new Vector2(j - 1, -i - 0.8f), Quaternion.identity);
                    Keyobj.transform.parent = transform;
                    Keyobj.name = "Key";
                }
            }
        }
        //Debug.Log((float)2 / 10);
        Instantiate(canvasUI, this.transform.position, Quaternion.identity);
    }
}
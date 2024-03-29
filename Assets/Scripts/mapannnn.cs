﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapannnn : MonoBehaviour
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
    public GameObject canvasUI;

    public GameObject floor;
    public GameObject start;
    public GameObject goal;
    public GameObject goal2;
    public GameObject player;
    public GameObject Key;
    public GameObject enemy;
    public GameObject enemy2;

    //public GameObject canvaUI;

    //public GameObject gm;

    //debug用
    //[SerializeField] public Camera cm;
    
    public int[,] map = new int[,]
    {
        { -7,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-8 },
        {-10,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-11},
        {-12,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-6},
        { -5,98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,-6 },
        { -5,99,-1, 0,-1,-1,-1,-1,-1,-1,-1, 0,-1, 0,-1,-1,-6 },
        { -5, 0, 0, 0,-1, 0, 0, 0,-1, 0, 0, 0,-1, 0, 0, 0,-6 },
        { -5, 0,-1,-1,-1, 0,-1, 0,-1, 0,-1, 0,-1, 0,-1, 0,-6 },
        { -5, 0,-1, 0,-1, 0, 0, 3, 0, 0, 0, 0,-1, 0,-1, 0,-6 },
        { -5,-1,-1, 0,-1, 0,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-6 },
        { -5, 0,-1, 0, 0, 0,-1, 0, 0, 0, 0, 0, 0, 0, 0, 0,-6 },
        { -5, 0,-1, 0,-1,-1,-1, 0,-1,-1,-1, 0,-1,-1,-1, 0,-6 },
        { -5, 0, 0, 0, 0, 0, 0, 0, 0, 0,-1, 0, 0, 0,-1, 0,-6 },
        { -5,-1,-1, 0,-1,-1,-1,-1,-1, 0,-1, 0,-1, 0,-1, 0,-6 },
        { -5, 0, 0, 0,-1, 0, 0, 0,-1, 0, 0, 0,-1, 0, 0, 0,-6 },
        { -5, 0,-1,-1,-1, 0,-1, 0,-1,-1,-1, 0,-1,-1,-1,-1,-6 },
        { -5, 0,-1, 0, 0, 0,-1, 0, 0, 0, 0, 0, 0, 0, 0, 2,-6 },
        { -5, 0,-1, 0,-1,-1,-1, 0,-1, 0,-1,-1,-1,-1,-1, 0,-6 },
        { -5, 1, 0, 0,-1, 0, 0, 0,-1, 0,-1,10, 0, 0, 0, 0,-6 },
        { -2,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-3 },
        { -13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13 },
        { -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1 },
        { -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1 },
        { -9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9 },
    };

    private void Start()
    {
        Instantiate(canvasUI, new Vector2(0, 0), Quaternion.identity);
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


                if (map[i, j] != 1)
                {
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                }
                if (map[i, j] == 1)
                {
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    Instantiate(start, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    GameObject playerobj = Instantiate(player, new Vector2(j - 1, -i - 0.8f), Quaternion.identity);
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
                    // Instantiate(goal, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    GameObject goalobj = Instantiate(goal, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    goalobj.name = "Goal";
                }
                if (map[i, j] == 3)
                {
                    Instantiate(floor, new Vector2(j - 1, -i - 1), Quaternion.identity);
                    GameObject enemyobj = Instantiate(enemy, new Vector2(j - 1, -i - 0.8f), Quaternion.identity);
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
       // Instantiate(gm, this.transform.position, Quaternion.identity);
    }

    //debug用
    //private void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        debugn += 1;
    //    }

    //    int ww = debugn % 2;
    //    if (ww == 0)
    //    {
    //        cm.depth = 0;
    //    }
    //    else if (ww == 1)
    //    {
    //        cm.depth = 2;
    //    }
    //    Debug.Log(debugn);
    //}
}

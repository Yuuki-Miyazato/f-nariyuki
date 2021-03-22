using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage : MonoBehaviour
{
    public GameObject wall;    //壁用オブジェクト
    public GameObject wall2;    //外壁用オブジェクト
    public GameObject floor;    //床用オブジェクト
    public GameObject start;   //スタート地点に配置するオブジェクト
    public GameObject goal;    //ゴール地点に配置するオブジェクト
    public GameObject player;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject item;

    public int[,] stageArray = new int[5, 5]
{
        { 0, 0, 0, 0, 0},
        { 0, 1, 0, 1, 0},
        { 0, 0, 0, 2, 0},
        { 0, 1, 6, 1, 0},
        { 0, 0, 0, 0, 0},
};
    public int[,] stageArray2 = new int[5, 5]
{
        { 0, 0, 0, 0, 0},
        { 0, 1, 1, 1, 1},
        { 0, 0, 0, 0, 0},
        { 1, 1, 1, 1, 0},
        { 0, 3, 0, 0, 0},
};
    public int[,] stageArray3 = new int[5, 5]
 {
        { 1, 1, 0, 1, 1},
        { 1, 0, 0, 0, 1},
        { 0, 0, 1, 0, 0},
        { 1, 0, 4, 0, 1},
        { 1, 1, 0, 1, 1},
 };
    public int[,] stageArray4 = new int[,]
{
        { 1, 1, 7, 1, 1},
        { 1, 1, 0, 1, 1},
        { 0, 0, 5, 0, 0},
        { 1, 1, 0, 1, 1},
        { 1, 1, 0, 1, 1},
};
    public int[,] stageArray5 = new int[,]
    {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},

    };
    private void Start()
    {
        makestage1();
        makestage2();
        makestage3();
        makestage4();
        makestage5();
    }
    void makestage1()
    {
        for (int i = 0; i < stageArray.GetLength(0); i++)
        {
            for (int j = 0; j < stageArray.GetLength(1); j++)
            {
                //範囲外、または壁の場合に壁オブジェクトを生成する
                if (stageArray[i, j] == 1)
                {
                    Instantiate(wall, new Vector2(i, j), Quaternion.identity);
                }
                if (stageArray[i, j] != 10)
                {
                    //全ての場所に床オブジェクトを生成
                    Instantiate(floor, new Vector2(i, j), Quaternion.identity);
                }
                if (stageArray[i, j] == 2)
                {
                    GameObject enemyObj = Instantiate(enemy, new Vector2(i , j), Quaternion.identity) as GameObject;
                    enemyObj.transform.parent = transform;
                }
            }
        }
    }
    void makestage2()
    {
        for (int i = 0; i < stageArray2.GetLength(0); i++)
        {
            for (int j = 0; j < stageArray2.GetLength(1); j++)
            {
                //範囲外、または壁の場合に壁オブジェクトを生成する
                if (stageArray2[i, j] == 1)
                {
                    Instantiate(wall, new Vector2(i + 5, j + 5), Quaternion.identity);
                }
                if (stageArray2[i, j] != 10)
                {
                    //全ての場所に床オブジェクトを生成
                    Instantiate(floor, new Vector2(i + 5, j + 5), Quaternion.identity);
                }
                if (stageArray2[i, j] == 3)
                {
                    GameObject enemyObj2 = Instantiate(enemy2, new Vector2(i + 5, j + 5), Quaternion.identity) as GameObject;
                    enemyObj2.transform.parent = transform;
                }
            }
        }
    }
    void makestage3()
    {
        for (int i = 0; i < stageArray3.GetLength(0); i++)
        {
            for (int j = 0; j < stageArray3.GetLength(1); j++)
            {
                //範囲外、または壁の場合に壁オブジェクトを生成する
                if (stageArray3[i, j] == 1)
                {
                    Instantiate(wall, new Vector2(i, j + 5), Quaternion.identity);
                }
                if (stageArray3[i, j] != 10)
                {
                    //全ての場所に床オブジェクトを生成
                    Instantiate(floor, new Vector2(i, j + 5), Quaternion.identity);
                }
            }
        }
    }
    void makestage4()
    {
        for (int i = 0; i < stageArray4.GetLength(0); i++)
        {
            for (int j = 0; j < stageArray4.GetLength(1); j++)
            {
                //範囲外、または壁の場合に壁オブジェクトを生成する
                if (stageArray4[i, j] == 1)
                {
                    Instantiate(wall, new Vector2(i + 5, j), Quaternion.identity);
                }
                if (stageArray4[i, j] != 10)
                {
                    //全ての場所に床オブジェクトを生成
                    Instantiate(floor, new Vector2(i + 5, j), Quaternion.identity);
                }
                if (stageArray4[i, j] == 5)
                {
                    GameObject playerObj = Instantiate(player, new Vector2(i + 5, j), Quaternion.identity) as GameObject;
                    playerObj.transform.parent = transform;
                    playerObj.name = "Player";
                }
            }
        }
    }
    void makestage5()
    {
        for (int i = 0; i < stageArray5.GetLength(0); i++)
        {
            for (int j = 0; j < stageArray5.GetLength(1); j++)
            {
                //範囲外、または壁の場合に壁オブジェクトを生成する
                if (stageArray5[i, j] == 1)
                {
                    Instantiate(wall2, new Vector2(i - 1, j - 1), Quaternion.identity);
                }
            }
        }
    }
    void Update()
    {
    }
}

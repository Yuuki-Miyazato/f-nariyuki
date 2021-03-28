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
    public GameObject item;
    private int stagecount1 = 0;
    private int stagecount2 = 0;
    private int stagecount3 = 0;
    private int stagecount4 = 0;
    private int stagecount5 = 0;
    private int stagecount6 = 0;
    private int stagecount7 = 0;
    private int stagecount8 = 0;
    private int stagecount9 = 0;

    public int[,] stageArray = new int[,]
{
        { 0, 0, 0, 0, 0},
        { 0, 1, 0, 1, 0},
        { 0, 0, 0, 0, 0},
        { 0, 1, 6, 1, 0},
        { 0, 0, 0, 0, 0},
};
    public int[,] stageArray2 = new int[,]
{
        { 0, 0, 0, 0, 0},
        { 0, 1, 1, 1, 1},
        { 0, 0, 0, 0, 0},
        { 1, 1, 1, 1, 0},
        { 0, 3, 0, 0, 0},
};
    public int[,] stageArray3 = new int[,]
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
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},

    };
    private void Start()
    {
        makestage();
    }
    void makestage()
    {
        stagecount1 = Random.Range(1, 4);
        stagecount2 = Random.Range(1, 4);
        stagecount3 = Random.Range(1, 4);
        stagecount4 = Random.Range(1, 4);
        stagecount5 = Random.Range(1, 4);
        stagecount6 = Random.Range(1, 4);
        stagecount7 = Random.Range(1, 4);
        stagecount8 = Random.Range(1, 4);
        stagecount9 = Random.Range(1, 4);

        if (stagecount1 == 1)
        {
            //タイル１の設定
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i, j), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount1 == 2)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray2[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i, j), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount1 == 3)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray3[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i, j), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount1 == 4)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray4[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i, j), Quaternion.identity);
                    }
                }
            }
        }
        if (stagecount2 == 1)
        {
            //タイル２の設定
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 10, j), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount2 == 2)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray2[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 10, j), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount2 == 3)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray3[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 10, j), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount2 == 4)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray4[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 10, j), Quaternion.identity);
                    }
                }
            }
        }
        if (stagecount3 == 1)
        {
            //タイル３の設定
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 10, j + 5), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount3 == 2)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray2[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 10, j + 5), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount3 == 3)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray3[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 10, j + 5), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount3 == 4)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray4[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 10, j + 5), Quaternion.identity);
                    }
                }
            }
        }
        if (stagecount4 == 1)
        {
            //タイル４の設定
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 5, j + 5), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount4 == 2)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray2[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 5, j + 5), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount4 == 3)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray3[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 5, j + 5), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount4 == 4)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray4[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 5, j + 5), Quaternion.identity);
                    }
                }
            }
        }
        if (stagecount5 == 1)
        {
            //タイル5の設定
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 10, j + 10), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount5 == 2)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray2[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 10, j + 10), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount5 == 3)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray3[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 10, j + 10), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount5 == 4)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray4[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 10, j + 10), Quaternion.identity);
                    }
                }
            }
        }

        if (stagecount6 == 1)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 5, j), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount6 == 2)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray2[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 5, j), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount6 == 3)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray3[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 5, j), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount6 == 4)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray4[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 5, j), Quaternion.identity);
                    }
                }
            }
        }

        if (stagecount7 == 1)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i, j + 5), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount7 == 2)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray2[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i, j + 5), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount7 == 3)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray3[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i, j + 5), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount7 == 4)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray4[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i, j + 5), Quaternion.identity);
                    }
                }
            }
        }
        if (stagecount8 == 1)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i, j + 10), Quaternion.identity);
                    }
                }
            }
        }
        if (stagecount8 == 2)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray2[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i, j + 10), Quaternion.identity);
                    }
                }
            }
        }
        if (stagecount8 == 3)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray3[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i, j + 10), Quaternion.identity);
                    }
                }
            }
        }
        else if (stagecount8 == 4)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray4[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i, j + 10), Quaternion.identity);
                    }
                }
            }
        }
        if (stagecount9 == 1)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 5, j + 10), Quaternion.identity);
                    }
                }
            }
        }
        if (stagecount9 == 2)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray2[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 5, j + 10), Quaternion.identity);
                    }
                }
            }
        }
        if (stagecount9 == 3)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray3[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 5, j + 10), Quaternion.identity);
                    }
                }
            }
        }
        if (stagecount9 == 4)
        {
            for (int i = 0; i < stageArray.GetLength(0); i++)
            {
                for (int j = 0; j < stageArray.GetLength(1); j++)
                {
                    if (stageArray4[i, j] == 1)
                    {
                        Instantiate(wall, new Vector2(i + 5, j + 10), Quaternion.identity);
                    }
                }
            }
        }

        for (int i = 0; i < stageArray.GetLength(0); i++)
        {
            for (int j = 0; j < stageArray.GetLength(1); j++)
            {
                if (stageArray4[i, j] == 5)
                {
                    GameObject playerObj = Instantiate(player, new Vector2(i + 5, j + 9), Quaternion.identity) as GameObject;
                    playerObj.transform.parent = transform;
                    playerObj.name = "Player";
                }
                if (stageArray[i, j] == 2)
                {
                    GameObject enemyObj = Instantiate(enemy, new Vector2(i, j), Quaternion.identity) as GameObject;
                    enemyObj.transform.parent = transform;
                }
                if (stageArray2[i, j] == 3)
                {
                    GameObject enemyObj = Instantiate(enemy2, new Vector2(i+8, j+8), Quaternion.identity) as GameObject;
                    enemyObj.transform.parent = transform;
                }
            }
        }
        for (int i = 0; i < stageArray5.GetLength(0); i++)
        {
            for (int j = 0; j < stageArray5.GetLength(1); j++)
            {
                //外壁を生成
                if (stageArray5[i, j] == 1)
                {
                    Instantiate(wall2, new Vector2(i - 1, j - 1), Quaternion.identity);
                }
                if (stageArray5[i, j] == 0)
                {
                    //外壁以外を全て床にする
                    Instantiate(floor, new Vector2(i - 1, j - 1), Quaternion.identity);
                }
            }
        }
    }
}

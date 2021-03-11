using UnityEngine;

public class enemyspown : MonoBehaviour
{
    public Vector3 pos;
    [SerializeField] private MakeDungeon mkd;
    [SerializeField] public int[,] searctbl ;
    [SerializeField] public int Ix, Iy;
    [SerializeField] public int rx, ry;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject kari;
    private bool tblflag;
    private bool ranflag;

    private void Start()
    {
        Ix = 0;
        Iy = 0;
        rx = Random.Range(0, 21);
        ry = Random.Range(0, 21);
        //rx = 0;
        //ry = 0;
        searctbl =new int[mkd.max, mkd.max];
        tblflag = false;
        ranflag = false;
        mkd.walls[0, 0] = -99;
        if (mkd.walls[0, 0] == -99)
        {
            GameObject obj1 = Instantiate(kari, new Vector3(0, 0, 0), Quaternion.identity);
        }
        //Debug.Log(mkd.walls[rx,ry]);
        //Debug.Log(rx);
        //Debug.Log(ry);
    }

    private void Update()
    {
        if (tblflag == false)
        {
            for (int i = 0; i < mkd.max; i++)
            {
                for (int j = 0; j < mkd.max; j++)
                {
                    
                    searctbl[i, j] = mkd.walls[i, j];
                    if (mkd.walls[rx, ry] == 1 && ranflag == false)
                    {
                        mkd.walls[rx, ry] = -1;
                        Ix = rx;
                        Iy = ry;
                        pos = new Vector3(rx * 1, ry * 1, 0);
                        ranflag = true;
                        //Debug.Log(rx);
                        //Debug.Log(ry);
                    }
                    else
                    {
                        if (mkd.walls[rx, ry] != 1 && ranflag == false)
                        {
                            while (mkd.walls[rx, ry] != 1)
                            {
                                rx = Random.Range(0, 21);
                                ry = Random.Range(0, 21);
                            }
                            mkd.walls[rx, ry] = -1;
                            Ix = rx;
                            Iy = ry;
                            pos = new Vector3(rx * 1, ry * 1, 0);
                            ranflag = true;
                            //Debug.Log(rx);
                            //Debug.Log(ry);
                        }
                    }
                    //if (mkd.walls[i, j] == -1)
                    //{
                    //    Ix = i;
                    //    Iy = j;
                    //    pos = new Vector3(i * 1, j * 1, 0);
                    //}
                }
            }
            GameObject obj = (GameObject)Instantiate(enemy, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            obj.name = "Enemy";
            //Debug.Log(Ix);
            //Debug.Log(Iy);
            tblflag = true;
        }
    }
}

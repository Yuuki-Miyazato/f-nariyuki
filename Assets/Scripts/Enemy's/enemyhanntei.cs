using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhanntei : MonoBehaviour
{
    GameObject GM;
    [SerializeField] enemyspown es;
    [SerializeField] MakeDungeon mkd;
    //Vector2 pos = new Vector2(0, 0);
    [SerializeField] private GameObject left, right, up, down;
    [SerializeField] public int ixl, ixr, iyu, iyd;
    [SerializeField] private float rBox,lBox,uBox,dBox;
    [SerializeField] private GameObject leftobj, rightobj, upobj, downobj;
    [SerializeField] public int ls, rs, us, ds;
    public bool wfl;

    public void Start()
    {
        ixl = 1;
        ixr = 1;
        iyu = 1;
        iyd = 1;
        wfl = false;
        GM = GameObject.Find("random");
        es = GM.GetComponent<enemyspown>();
        mkd = GM.GetComponent<MakeDungeon>();

        left.SetActive(true);
        down.SetActive(true);
        right.SetActive(true);
        up.SetActive(true);

        //while (Sct.Ix - ixl > 0&&mkd.walls[Sct.Ix - ixl, Sct.Iy] == 1)
        //{

        //    ixl += 1;
        //}
        //Box = (float)ixl / 2f;
        //GameObject leftobj = (GameObject)Instantiate(left, new Vector3(Sct.pos.x - Box, Sct.pos.y, Sct.pos.z), Quaternion.identity);
        //leftobj.transform.parent = transform;
        //leftobj.name = "left";



        //while (Sct.Ix+ixr<21&&mkd.walls[Sct.Ix + ixr, Sct.Iy] == 1)
        //{
        //    ixr += 1;
        //}
        //Box = (float)ixr / 2f;
        //GameObject rightobj = (GameObject)Instantiate(right, new Vector3(Sct.pos.x + Box, Sct.pos.y, Sct.pos.z), Quaternion.identity);
        //rightobj.transform.parent = transform;
        //rightobj.name = "right";


        //while (Sct.Iy+iyu<21&&mkd.walls[Sct.Ix, Sct.Iy + iyu] == 1)
        //{
        //    iyu += 1;
        //}
        //Box = (float)iyu / 2f;
        //GameObject upobj = (GameObject)Instantiate(up, new Vector3(Sct.pos.x, Sct.pos.y + Box, Sct.pos.z), Quaternion.identity);
        //upobj.transform.parent = transform;
        //upobj.name = "up";


        //while (Sct.Iy-iyd>0&&mkd.walls[Sct.Ix, Sct.Iy - iyd] == 1)
        //{
        //    iyd += 1;
        //}
        //Box = (float)iyd / 2f;
        //GameObject downobj = (GameObject)Instantiate(down, new Vector3(Sct.pos.x, Sct.pos.y - Box, Sct.pos.z), Quaternion.identity);
        //downobj.transform.parent = transform;
        //downobj.name = "down";

        //Debug.Log(iyu);
        //Debug.Log(Box);
    }

    private void FixedUpdate()
    {
        if (wfl == false)
        {
            Destroy(leftobj);
            Destroy(rightobj);
            Destroy(upobj);
            Destroy(downobj);

            wfl = EnemyH();

            leftobj = (GameObject)Instantiate(left, new Vector3(es.Ix - lBox, es.Iy, es.pos.z), Quaternion.identity);
            leftobj.name = "left";
            if (lBox >= 1f)
            {
                //left.SetActive(false);
                //leftobj.transform.parent = transform;
                
                ls = 1;
            }

            rightobj = (GameObject)Instantiate(right, new Vector3(es.Ix + rBox, es.Iy, es.pos.z), Quaternion.identity);
            rightobj.name = "right";
            if (rBox >= 1f)
            {
                //right.SetActive(false);
                //rightobj.transform.parent = transform;
               
                rs = 1;
            }

            upobj = (GameObject)Instantiate(up, new Vector3(es.Ix, es.Iy + uBox, es.pos.z), Quaternion.identity);
            upobj.name = "up";
            if (uBox >= 1f)
            {  
                //up.SetActive(false);
                //upobj.transform.parent = transform;
               
                us = 1;
            }

            downobj = (GameObject)Instantiate(down, new Vector3(es.Ix, es.Iy - dBox, es.pos.z), Quaternion.identity);
            downobj.name = "down";
            if (dBox >= 1f)
            {
                //down.SetActive(false);
                //downobj.transform.parent = transform;
                ds = 1;
            }

            //leftobj = (GameObject)Instantiate(left, new Vector3(es.pos.x - lBox, es.pos.y, es.pos.z), Quaternion.identity);
            //leftobj.transform.parent = transform;
            //leftobj.name = "left";

            //rightobj = (GameObject)Instantiate(right, new Vector3(es.pos.x + rBox, es.pos.y, es.pos.z), Quaternion.identity);
            //rightobj.transform.parent = transform;
            //rightobj.name = "right";

            //upobj = (GameObject)Instantiate(up, new Vector3(es.pos.x, es.pos.y + uBox, es.pos.z), Quaternion.identity);
            //upobj.transform.parent = transform;
            //upobj.name = "up";

            //downobj = (GameObject)Instantiate(down, new Vector3(es.pos.x, es.pos.y - dBox, es.pos.z), Quaternion.identity);
            //downobj.transform.parent = transform;
            //downobj.name = "down";


           // Debug.Log("生成");
        }
        //if (wfl == false)
        //{
        //    //Debug.Log(Sct.Ix);
        //    while (Sct.Ix - ixl > 0 && mkd.walls[Sct.Ix - ixl, Sct.Iy] == 1)
        //    {

        //        ixl += 1;
        //    }
        //    Box = (float)ixl / 2f;
        //    GameObject leftobj = (GameObject)Instantiate(left, new Vector3(Sct.pos.x - Box, Sct.pos.y, Sct.pos.z), Quaternion.identity);
        //    leftobj.transform.parent = transform;
        //    leftobj.name = "left";



        //    while (Sct.Ix + ixr < 21 && mkd.walls[Sct.Ix + ixr, Sct.Iy] == 1)
        //    {
        //        ixr += 1;
        //    }
        //    Box = (float)ixr / 2f;
        //    GameObject rightobj = (GameObject)Instantiate(right, new Vector3(Sct.pos.x + Box, Sct.pos.y, Sct.pos.z), Quaternion.identity);
        //    rightobj.transform.parent = transform;
        //    rightobj.name = "right";


        //    while (Sct.Iy + iyu < 21 && mkd.walls[Sct.Ix, Sct.Iy + iyu] == 1)
        //    {
        //        iyu += 1;
        //    }
        //    Box = (float)iyu / 2f;
        //    GameObject upobj = (GameObject)Instantiate(up, new Vector3(Sct.pos.x, Sct.pos.y + Box, Sct.pos.z), Quaternion.identity);
        //    upobj.transform.parent = transform;
        //    upobj.name = "up";


        //    while (Sct.Iy - iyd > 0 && mkd.walls[Sct.Ix, Sct.Iy - iyd] == 1)
        //    {
        //        iyd += 1;
        //    }
        //    Box = (float)iyd / 2f;
        //    GameObject downobj = (GameObject)Instantiate(down, new Vector3(Sct.pos.x, Sct.pos.y - Box, Sct.pos.z), Quaternion.identity);
        //    downobj.transform.parent = transform;
        //    downobj.name = "down";

        //    wfl = true;
        //}
    }


    public bool EnemyH()
    {

        //Debug.Log(Sct.Ix);
        while (es.Ix - ixl > 0 && mkd.walls[es.Ix - ixl, es.Iy] == 1)
            {
                ixl += 1;
            }
            lBox = (float)ixl / 2f;
            //leftobj = (GameObject)Instantiate(left, new Vector3(Sct.pos.x - lBox, Sct.pos.y, Sct.pos.z), Quaternion.identity);
            //leftobj.transform.parent = transform;
            //leftobj.name = "left";



            while (es.Ix + ixr < 21 && mkd.walls[es.Ix + ixr, es.Iy] == 1)
            {
                ixr += 1;
            }
            rBox = (float)ixr / 2f;
            //rightobj = (GameObject)Instantiate(right, new Vector3(Sct.pos.x + rBox, Sct.pos.y, Sct.pos.z), Quaternion.identity);
            //rightobj.transform.parent = transform;
            //rightobj.name = "right";


            while (es.Iy + iyu < 21 && mkd.walls[es.Ix, es.Iy + iyu] == 1)
            {
                iyu += 1;
            }
            uBox = (float)iyu / 2f;
            //upobj = (GameObject)Instantiate(up, new Vector3(Sct.pos.x, Sct.pos.y + uBox, Sct.pos.z), Quaternion.identity);
            //upobj.transform.parent = transform;
            //upobj.name = "up";


            while (es.Iy - iyd > 0 && mkd.walls[es.Ix, es.Iy - iyd] == 1)
            {
                iyd += 1;
            }
        dBox = (float)iyd / 2f;
        //downobj = (GameObject)Instantiate(down, new Vector3(Sct.pos.x, Sct.pos.y - dBox, Sct.pos.z), Quaternion.identity);
        //downobj.transform.parent = transform;
        //downobj.name = "down";

        //Debug.Log("ok");

        return true;
    }
}

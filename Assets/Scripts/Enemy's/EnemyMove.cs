using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]private GameObject Enemy;
    [SerializeField] private GameObject randam;
    [SerializeField] private enemyhanntei eh;
    [SerializeField] private MakeDungeon mkd;
    [SerializeField]private enemyspown es;
    [SerializeField] private left sleft;
    [SerializeField] private right sright;
    [SerializeField] private up sup;
    [SerializeField] private down sdown;
    [SerializeField]public int sx,sy;
    private Rigidbody2D rb;
    //private Vector2 Startpos;
    private Vector2 StartPos;
    public bool lflg, rflg, uflg, dflg;
    // public bool wallflg;
    [SerializeField] private float time;
    [SerializeField] private int hls, hrs, hus, hds;
    [SerializeField] private GameObject left, right, up, down;
    [SerializeField] private BoxCollider2D lbox, rbox, ubox, dbox;
    public bool playerhh;
   // Vector3 rpos,lpos,upos,dpos;

    private void Start()
    {
        lflg = false;
        rflg = false;
        uflg = false;
        dflg = false;
        //wallflg = false;
        sx = 0;
        sy = 0;
        rb = GetComponent<Rigidbody2D>();
        randam = GameObject.Find("random");
        mkd = randam.GetComponent<MakeDungeon>();
        es = randam.GetComponent<enemyspown>();

        //left = GameObject.Find("left");
        //right = GameObject.Find("right");
        //up = GameObject.Find("up");
        //down = GameObject.Find("down");

        StartPos = transform.position;

        hls = eh.ls;
        hds = eh.ds;
        hrs = eh.rs;
        hus = eh.us;

        playerhh = false;

        //rpos = new Vector3(0, 0, 0);
        //dpos = new Vector3(0, 0, 90);
        //rpos = new Vector3(0, 0, 180);
        //upos = new Vector3(0, 0, 270);

        //left.enabled = true;
        //down.enabled = true;
        //right.enabled = true;
        //up.enabled = true;

        //Startpos = new Vector2();
        // Enemy = GetComponent<GameObject>();
    }

    private void FixedUpdate()
    {
        left = GameObject.Find("left");
        right = GameObject.Find("right");
        up = GameObject.Find("up");
        down = GameObject.Find("down");
        lbox = left.GetComponent<BoxCollider2D>();
        rbox = right.GetComponent<BoxCollider2D>();
        ubox = up.GetComponent<BoxCollider2D>();
        dbox = down.GetComponent<BoxCollider2D>();

        if (lflg == true)
        {
            rb.velocity = new Vector2(-sx, 0);
        }
        else if (rflg == true)
        {
            rb.velocity = new Vector2(sx, 0);
        }
        else if (uflg == true)
        {
            rb.velocity = new Vector2(0, sy);
        }
        else if (dflg == true)
        {
            rb.velocity = new Vector2(0, -sy);
        }
        else
        {
           //rb.velocity = StartPos;
        }

        if (time >= 2)
        {
            if (hls == 0 && hds == 0 && hrs == 0 && hus == 0)
            {
                hls = eh.ls;
                hds = eh.ds;
                hrs = eh.rs;
                hus = eh.us;
                //Debug.Log("ok");
            }

            if (hls == 1)
            {
                //transform.rotation = new Quaternion(0, 0, 0, 0);
                //transform.LookAt(lpos);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                hls = 0;
                lbox.enabled = true;
                dbox.enabled = false;
                rbox.enabled = false;
                ubox.enabled = false;
                //Debug.Log("l");
                //Debug.Log(left.enabled);
            }
            else if (hds == 1)
            {
                //transform.rotation = new Quaternion(0, 0, 90, 0);
                //transform.LookAt(dpos);
                transform.rotation = Quaternion.Euler(0, 0, -90);
                hds = 0;
                lbox.enabled = false;
                dbox.enabled = true;
                rbox.enabled = false;
                ubox.enabled = false;
               // Debug.Log("d");
                //Debug.Log(down.enabled);
            }
            else if (hrs == 1)
            {
                //transform.rotation = new Quaternion(0, 0, 180, 0);
                //transform.LookAt(rpos);
                transform.rotation = Quaternion.Euler(0, 0, -180);
                hrs = 0;
                lbox.enabled = false;
                dbox.enabled = false;
                rbox.enabled = true;
                ubox.enabled = false;
               // Debug.Log("r");
                //Debug.Log(right.enabled);
            }
            else if (hus == 1)
            {
                //transform.rotation = new Quaternion(0,0,270,0);
                
                //transform.rotation=upos;
                //transform.LookAt(upos);
                transform.rotation = Quaternion.Euler(0, 0, -270);
                hus = 0;
                lbox.enabled = false ;
                dbox.enabled = false;
                rbox.enabled = false;
                ubox.enabled = true;
                //Debug.Log("u");
                //Debug.Log(up.enabled);
            }
            time = 0;
        }
        if (playerhh == false)
        {
            time += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Stop");
        if (collision.gameObject.tag == "Wall")
        {
            if (lflg == true)
            {
                es.Ix = es.Ix - eh.ixl -1;
                Debug.Log(es.Ix);
                if (es.Ix <= -1)
                {
                    es.Ix = 0;
                }
                mkd.walls[es.Ix, es.Iy] = -1;
            }
            else if (rflg == true)
            {
                Debug.Log(es.Ix);
                es.Ix = es.Ix + eh.ixr -1;
                Debug.Log(es.Ix);
                if (es.Ix >= 22)
                {
                    es.Ix = 21;
                }
                mkd.walls[es.Ix, es.Iy] = -1;
            }
            else if (uflg == true)
            {
                Debug.Log(es.Iy);
                es.Iy = es.Iy + eh.iyu -1;
                Debug.Log(es.Iy);
                if (es.Iy >= 22)
                {
                    es.Iy = 21;
                }
                mkd.walls[es.Ix, es.Iy] = -1;
            }
            else if (dflg == true)
            {
                Debug.Log(es.Iy);
                es.Iy = es.Iy - eh.iyd -1;
                Debug.Log(es.Iy);
                if (es.Iy <= -1)
                {
                    es.Iy = 0;
                }
                mkd.walls[es.Ix, es.Iy] = -1;
            }
            eh.Start();
            lflg = false;
            rflg = false;
            uflg = false;
            dflg = false;
            eh.wfl = false;
            
            sy = 0;
            sx = 0;
           // Debug.Log(sx);
         //   Debug.Log(sy);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Wall")
    //    {
    //        if (lflg == true)
    //        {
    //            es.Ix = es.Ix - eh.ixl-1 ;
    //            if (es.Ix <= -1)
    //            {
    //                es.Ix = 0;
    //            }
    //            mkd.walls[es.Ix, es.Iy] = -1;
    //        }
    //        else if (rflg == true)
    //        {
    //            es.Ix = es.Ix + eh.ixr-1 ;
    //            if (es.Ix >= 22)
    //            {
    //                es.Ix = 21;
    //            }
    //            mkd.walls[es.Ix, es.Iy] = -1;
    //        }
    //        else if (uflg == true)
    //        {
    //            es.Iy = es.Iy + eh.iyu -1;
    //            if (es.Iy >= 22)
    //            {
    //                es.Iy = 21;
    //            }
    //            mkd.walls[es.Ix, es.Iy] = -1;
    //        }
    //        else if (dflg == true)
    //        {
    //            es.Iy = es.Iy - eh.iyd -1;
    //            if (es.Iy <= -1)
    //            {
    //                es.Iy = 0;
    //            }
    //            mkd.walls[es.Ix, es.Iy] = -1;
    //        }
    //        eh.Start();
    //        lflg = false;
    //        rflg = false;
    //        uflg = false;
    //        dflg = false;
    //        eh.wfl = false;
    //    }
    //}

    private void StartRote()
    {
        if (eh.ls == 1)
        {
            //transform.Rotate(new Vector3(0, 0, 0));
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (eh.ds == 1)
        {
            //transform.Rotate(new Vector3(0, 0, 90));
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (eh.rs == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (eh.us == 1)
        {
            // transform.Rotate(new Vector3(0, 0, 270));
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }
}

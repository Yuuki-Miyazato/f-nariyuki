using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float moveTime;
    public bool isMoveing = false;

    public int R, L, U, D = 0;

    public int px;
    public int py;

    private Animator anim = null;
    public int AP = 4;

    public int attackDamage = 1;
    public int HP = 3;

    AudioSource audioSource;        //se用変数


    int vertical, horizontal;

    public LayerMask blockingLayer;
    private BoxCollider2D boxCollider;
    private Animator animator;

    private ModeChange script;
    private GameObject Player;
    public GameObject wall;

    //エフェクト↓
    [SerializeField] public GameObject Hiteffect;
    [SerializeField] private int hiteffectint = 0;
    [SerializeField] private float effectdeletime = 0.0f;

    [SerializeField] private GameObject goal;
    [SerializeField] private reset3 reset;

    public int houkou = 0;
    [SerializeField] private damegeAnimation dm;

    void Start()
    {

        goal = GameObject.FindWithTag("goal");
        reset = goal.GetComponent<reset3>();
        rd2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        //Component取得
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        Player = GameObject.Find("Player");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        script = Player.GetComponent<ModeChange>();

        dm = GetComponent<damegeAnimation>();
    }
    void Update()
    {
        Debug.Log(HP);
        if (reset.abc == true && dm.damege == false)
        {
            if (Time.deltaTime > 0)
            {
                if (GetComponent<PlayerController>().enabled == true)
                {
                    horizontal = (int)Input.GetAxisRaw("Horizontal");
                    vertical = (int)Input.GetAxisRaw("Vertical");
                }
                float pos_x = this.gameObject.transform.position.x;
                float pos_y = this.gameObject.transform.position.y;
                px = (int)pos_x;
                py = (int)pos_y;

                if (HP == 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                if (horizontal != 0)
                {
                    vertical = 0;
                    if (horizontal == 1)
                    {
                        R = 1;
                        U = 0;
                        L = 0;
                        D = 0;
                        houkou = 1;
                        anim.SetBool("walkR", true);
                        anim.SetBool("walkL", false);
                        anim.SetBool("walkB", false);
                        anim.SetBool("walkF", false);
                    }
                    else if (horizontal == -1)
                    {
                        L = 1;
                        R = 0;
                        U = 0;
                        D = 0;
                        houkou = 3;
                        anim.SetBool("walkL", true);
                        anim.SetBool("walkR", false);
                        anim.SetBool("walkB", false);
                        anim.SetBool("walkF", false);
                    }
                }
                else if (vertical != 0)
                {
                    horizontal = 0;
                    if (vertical == 1)
                    {
                        D = 1;
                        R = 0;
                        U = 0;
                        L = 0;
                        houkou = 2;
                        anim.SetBool("walkF", true);
                        anim.SetBool("walkL", false);
                        anim.SetBool("walkB", false);
                        anim.SetBool("walkR", false);
                    }
                    else if (vertical == -1)
                    {
                        U = 1;
                        R = 0;
                        L = 0;
                        D = 0;
                        houkou = 0;
                        anim.SetBool("walkB", true);
                        anim.SetBool("walkL", false);
                        anim.SetBool("walkR", false);
                        anim.SetBool("walkF", false);
                    }
                }
                else if (horizontal == 0 && vertical == 0)
                {
                    if (R == 1)
                    {
                        anim.SetBool("walkR", false);
                    }
                    else if (L == 1)
                    {
                        anim.SetBool("walkL", false);
                    }
                    if (D == 1)
                    {
                        anim.SetBool("walkF", false);
                    }
                    else if (U == 1)
                    {
                        anim.SetBool("walkB", false);
                    }
                }
                if (horizontal != 0 || vertical != 0)
                {
                    ATMove(horizontal, vertical);
                }
            }

            //hiteffectデリーと処理
            if (hiteffectint > 0)
            {
                effectdeletime += 0.02f;
                if (effectdeletime > 1.0)
                {
                    GameObject effectdeletobj = GameObject.Find("Hit");
                    Destroy(effectdeletobj);
                    effectdeletime = 0.0f;
                    hiteffectint -= 1;
                }
            }
        }
        else
        {
            anim.SetBool("walkF", false);
            anim.SetBool("walkB", false);
            anim.SetBool("walkR", false);
            anim.SetBool("walkL", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hiteffectint += 1;
            GameObject hiteffectobj = Instantiate(Hiteffect, this.transform.position, Quaternion.identity);
            hiteffectobj.name = "Hit";
            HP -= 1;
        }
    }
    public void ATMove(int horizontal, int vertical)
    {
        RaycastHit2D hit;

        bool canMove = Move(horizontal, vertical, out hit);

        if (hit.transform == null)
        {
            return;
        }
    }
    public bool Move(int horizontal, int vertical, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;

        Vector2 end = start + new Vector2(horizontal, vertical);

        boxCollider.enabled = false;

        hit = Physics2D.Linecast(start, end, blockingLayer);

        boxCollider.enabled = true;

        if (!isMoveing && hit.transform == null)
        {
            StartCoroutine(Movement(end));

            audioSource.Play();

            if (script.Mode == 3)
            {
                Instantiate(wall, new Vector2(px, py), Quaternion.identity);
            }
            return true;
        }
        return false;
    }

    IEnumerator Movement(Vector3 end)
    {
        isMoveing = true;

        float remainingDistance = (transform.position - end).sqrMagnitude;

        while (remainingDistance > float.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, end, 1f / moveTime * Time.deltaTime);

            remainingDistance = (transform.position - end).sqrMagnitude;

            yield return null;

        }
        transform.position = end;

        isMoveing = false;
    }
}

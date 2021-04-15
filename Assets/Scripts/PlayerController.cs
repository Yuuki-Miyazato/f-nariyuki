using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float moveTime = 0.1f;
    public bool isMoveing = false;

    public int R, L, U, D = 0;
    public SpriteRenderer player;
    public Sprite mae;
    public Sprite migi;
    public Sprite hidari;
    public Sprite usiro;


    public int px;
    public int py;

    private int BP = 0;
    public int AP = 4;

    public int attackDamage = 1;
    public int HP = 3;

    AudioSource audioSource;        //se用変数


    int vertical, horizontal;

    public LayerMask blockingLayer;
    private BoxCollider2D boxCollider;
    private Animator animator;
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        //Component取得
        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        if (Time.deltaTime > 0)
        {
            if (GetComponent<PlayerController>().enabled == true)
            {
                horizontal = (int)Input.GetAxisRaw("Horizontal");
                vertical = (int)Input.GetAxisRaw("Vertical");
            }
            //int horizontal = (int)Input.GetAxisRaw("Horizontal");
            //int vertical = (int)Input.GetAxisRaw("Vertical");
            //Debug.Log("aaaaa");
            float pos_x = this.gameObject.transform.position.x;
            float pos_y = this.gameObject.transform.position.y;
            px = (int)pos_x;
            py = (int)pos_y;

            if (moveTime == 0.1f)
            {
                Invoke("speedTime", 5);
            }

            if (HP == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            if (Input.GetKeyDown("joystick button 1"))
            {
                BP = 1;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BP = 1;
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
                    player.sprite = migi;
                }
                else if (horizontal == -1)
                {
                    L = 1;
                    R = 0;
                    U = 0;
                    D = 0;
                    player.sprite = hidari;
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
                    player.sprite = usiro;
                }
                else if (vertical == -1)
                {
                    U = 1;
                    R = 0;
                    L = 0;
                    D = 0;
                    player.sprite = mae;
                }
            }
            if (horizontal != 0 || vertical != 0)
            {
                ATMove(horizontal, vertical);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2")
        {
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

        WallBreak hitComponent = hit.transform.GetComponent<WallBreak>();

        if (!canMove && hitComponent != null && BP == 1)
        {
            OncantMove(hitComponent);
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
    public void OncantMove(WallBreak hit)
    {
        if (BP == 1 && AP > 0)
        {
            hit.DamageWall(attackDamage);
            BP = 0;
            AP -= 1;
        }
    }
    void speedTime()
    {
        moveTime = 0.3f;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float moveTime = 0.1f;
    public bool isMoveing = false;

    public LayerMask blockingLayer;
    private BoxCollider2D boxCollider;
    
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        int horizontal = (int)Input.GetAxisRaw("Horizontal");
        int vertical = (int)Input.GetAxisRaw("Vertical");
        
        if(horizontal != 0)
        {
            vertical = 0;
            if(horizontal == 1)
            {
                transform.localScale = new Vector2((float)1.5, (float)1.5);
            }
            else if(horizontal == -1)
            {
                transform.localScale = new Vector2((float)1.5, (float)1.5);
            }
        }
        else if(vertical != 0)
        {
            horizontal = 0;
        }

        if(horizontal != 0 || vertical != 0)
        {
            ATMove(horizontal,vertical);
        }
    }

    public void ATMove(int horizontal,int vertical)
    {
        RaycastHit2D hit;

        bool canMove = Move(horizontal, vertical,out hit);

        if (hit.transform == null)
        {
            return;
        }

    }
    public bool Move(int horizontal,int vertical,out RaycastHit2D hit)
    {
        Vector2 start = transform.position;

        Vector2 end = start + new Vector2(horizontal, vertical);

        hit = Physics2D.Linecast(start, end, blockingLayer);

        boxCollider.enabled = true;

        if (!isMoveing && hit.transform == null)
        {
            StartCoroutine(Movement(end));

            return true;
        }
        return false;
    }

    IEnumerator Movement(Vector3 end)
    {
        isMoveing = true;

        float remainingDistance = (transform.position - end).sqrMagnitude;
        
        while(remainingDistance > float.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, end, 1f / moveTime * Time.deltaTime);

            remainingDistance = (transform.position - end).sqrMagnitude;

            yield return null;
        }
        transform.position = end;

        isMoveing = false;
    }
}
using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour
{
    public float moveTime = 0.1f;
    public bool isMoveing = false;
    public int attackDamage = 1;
    public LayerMask blockingLayer;

    private BoxCollider2D boxCollider;
    private Transform target;
    private bool skipMove = false;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void MoveEnemy()
    {
        if (!skipMove)
        {
            skipMove = true;
            int xDir = 0;
            int yDir = 0;

            if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
            {
                yDir = target.position.y > transform.position.y ? 1 : -1;
            }
            ATMove(xDir, yDir);
        }
        else
        {
            skipMove = false;
            return;
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
        PlayerController hitComponent = hit.transform.GetComponent<PlayerController>();
        if (!canMove && hitComponent != null)
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
    public void OncantMove(PlayerController hit)
    {
    }
    public void Death()
    {
        gameObject.SetActive(false);
    }
}

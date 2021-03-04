using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    public Vector2 lastMove;

    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Animate();
    }



    private void FixedUpdate()
    {
        MovePlayer();
    }



    private void MovePlayer()
    {
        rb.AddForce(movement.normalized * moveSpeed * 1.5f);
    }

    public void Animate()
    {
        if (Mathf.Abs(movement.x) > 0.5f)
        {
            lastMove.x = movement.x;
            lastMove.y = 0;
        }
        if (Mathf.Abs(movement.y) > 0.5f)
        {
            lastMove.y = movement.y;
            lastMove.x = 0;
        }

        animator.SetFloat("Dir_X", movement.x);
        animator.SetFloat("Dir_Y", movement.y);
        animator.SetFloat("LastMove_X", lastMove.x);
        animator.SetFloat("LastMove_Y", lastMove.y);
        animator.SetFloat("Input", movement.magnitude);
    }

}
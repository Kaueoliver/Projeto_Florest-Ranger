using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLenght = 10f;
    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;
    private Animator animator;

    private Collider2D rd;
    private Rigidbody2D bd;

    private bool facingLeft = true;
    // Start is called before the first frame update
    private void Start()
    {
        rd = GetComponent<Collider2D>();
        bd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }   

    // Update is called once per frame
    private void Update()
    {
        if (animator.GetBool("Jump")) 
        {
            if(bd.velocity.y < .1) 
            {
                animator.SetBool("Cair", true);
                animator.SetBool("Jump", false);
            }
        }
        if(rd.IsTouchingLayers(ground) && animator.GetBool("Cair")) 
        {
            animator.SetBool("Cair", false);
        }
            Move();
    }
    private void Move() 
    {
        if (facingLeft)
        {
            if (transform.position.x > leftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);

                }
                if (rd.IsTouchingLayers(ground))
                {
                    bd.velocity = new Vector2(-jumpLenght, jumpHeight);
                    animator.SetBool("Jump", true);
                }
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);

                }
                if (rd.IsTouchingLayers(ground))
                {
                    bd.velocity = new Vector2(jumpLenght, jumpHeight);
                    animator.SetBool("Jump", true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }

    }
}

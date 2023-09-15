using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLenght;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask ground;

    private Collider2D rd;
    private Rigidbody bd;

    private bool facingLeft = true;
    // Start is called before the first frame update
    private void Start()
    {
        rd = GetComponent<Collider2D>();
        bd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (facingLeft) 
        {
            if(transform.position.x > leftCap) 
            {
                if(transform.localScale.x != 1)     
                {
                    transform.localScale = new Vector3(1, 1);

                }
                if (rd.IsTouchingLayers(ground)) 
                {
                    bd.velocity = new Vector2(-jumpLenght, jumpHeight);
                }
            }
            else 
            {
                facingLeft = false;
            }
        }
        else 
        {
            if (transform.position.x > rightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);

                }
                if (rd.IsTouchingLayers(ground))
                {
                    bd.velocity = new Vector2(jumpLenght, jumpHeight);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    }
}

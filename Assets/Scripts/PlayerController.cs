using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rig;
    [SerializeField]private LayerMask Ground;
    private Collider2D coll;
    

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

    private void move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if (Input.GetAxis("Horizontal") < 0f) 
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }


    }

    private void jump() 
    {
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(Ground)) 
        {
            rig.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
        }
    }
}

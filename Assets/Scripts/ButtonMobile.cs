using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;


/*public class ButtonMobile : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float hurtForce = 10f;


    private Collider2D coll;
    private Animator anim;
    private Rigidbody2D rig;
    [SerializeField] private int cherries = 0;
    [SerializeField] private TextMeshProUGUI cherryText;


    private enum State { idle, walk, Jump, cair, hurt }
    private State state = State.idle;




    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //move();
        //jump();
        if (state != State.hurt)
        {
            Movement();
        }

        AnimationState();
        anim.SetInteger("state", (int)state);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coletável")
        {

            Destroy(collision.gameObject);
            cherries += 1;

            cherryText.text = cherries.ToString();
            Debug.Log(cherryText.text);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (state == State.cair)
            {
                Destroy(other.gameObject);
                Jump();
            }
            else
            {
                state = State.hurt;

                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    rig.velocity = new Vector2(-hurtForce, rig.velocity.y);
                }
                else
                {
                    rig.velocity = new Vector2(hurtForce, rig.velocity.y);
                }
            }
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D ground = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.1f, Ground);
        return ground.collider != null;
    }





    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        //Mover para a esquerda
        if (hDirection < 0)
        {
            rig.velocity = new Vector2(-speed, rig.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        //Mover Para a direita
        else if (hDirection > 0)
        {
            rig.velocity = new Vector2(speed, rig.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }



    }

    private void Jump()
    {
        rig.velocity = new Vector2(rig.velocity.x, jumpForce);
        state = State.Jump;
    }

    private void AnimationState()
    {
        if (state == State.Jump)
        {
            if (rig.velocity.y < 1f)
            {
                state = State.cair;
            }
        }
        else if (state == State.cair)
        {
            if (isGrounded())
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if (Mathf.Abs(rig.velocity.x) < 1f)
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rig.velocity.x) > 1f)
        {
            state = State.walk;
        }
        else
        {
            state = State.idle;
        }




        /*private Rigidbody2D rb;
        private bool moveLeft;
        private bool moveRight;
        private float horizontalMove;
        public float speed = 5;
        public float jumpSpeed = 5;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            moveLeft = false;
            moveRight = false;
        }

        //I am pressing the left button
        public void PointerDownLeft()
        {
            moveLeft = true;
        }

        //I am not pressing the left button
        public void PointerUpLeft()
        {
            moveLeft = false;
        }

        //Same thing with the right button
        public void PointerDownRight()
        {
            moveRight = true;
        }

        public void PointerUpRight()
        {
            moveRight = false;
        }

        // Update is called once per frame
        void Update()
        {
            MovementPlayer();

        }

        //Now let's add the code for moving
        private void MovementPlayer()
        {
            //If i press the left button
            if (moveLeft)
            {
                horizontalMove = -speed;
                transform.localScale = new Vector2(-1, 1);
            }

            //if i press the right button
            else if (moveRight)
            {
                horizontalMove = speed;
                transform.localScale = new Vector2(1, 1);
            }

            //if i am not pressing any button
            else
            {
                horizontalMove = 0;
            }
        }

        public void jumpButton()
        {
            if (rb.velocity.y == 0)
            {
                rb.velocity = Vector2.up * jumpSpeed;
            }
        }

        //add the movement force to the player
        private void FixedUpdate()
        {
            rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        }*/
    //}
//}
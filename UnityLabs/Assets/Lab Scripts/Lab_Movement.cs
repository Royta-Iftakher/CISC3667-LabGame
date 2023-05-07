using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab_Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] public bool isSpriteRight = true;
    [SerializeField] bool isJumpPressed = false;
    [SerializeField] bool isGrounded = true;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool shiftPressed = false;

    //Shooting Component:
    [SerializeField] public GameObject shoeLeft, shoeRight;
    [SerializeField] Vector2 shoePos;
    [SerializeField] public float fireRate = 0.5f;
    [SerializeField] float nextFire = 0.0f;

    [SerializeField] Animator anim;
    const int IDLE = 0;
    const int WALK = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        speed = 15;
        if (anim == null) {
        anim = GetComponent<Animator>();
        }
        anim.SetInteger("State", IDLE);

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            isJumpPressed = true;
        }

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }

    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if(movement < 0 && isSpriteRight || movement > 0 && !isSpriteRight)
        {
            Flip();
        }
        if(isJumpPressed && isGrounded)
        {
            Jump();
        } else
        {
            isJumpPressed = false;
            if (isGrounded)
            {
                if (movement > 0 || movement < 0)
                {
                    anim.SetInteger("State", WALK);
                }
                else
                {
                    anim.SetInteger("State", IDLE);
                }
            }
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isSpriteRight = !isSpriteRight;
    }

    void Jump()
    {
        SoundManagerScript.PlaySound("Jump");
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        isGrounded = false;
        isJumpPressed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        //anim.SetInteger("State", IDLE);
    }

    void Fire()
    {
        SoundManagerScript.PlaySound("Shoot");
        shoePos = transform.position;
        if (isSpriteRight)
        {
            shoePos += new Vector2(+1f, -0.45f);
            Instantiate(shoeRight, shoePos, Quaternion.identity);
        } else
        {
            shoePos += new Vector2(-1f, -0.45f);
            Instantiate(shoeLeft, shoePos, Quaternion.identity);
        }
    }

}

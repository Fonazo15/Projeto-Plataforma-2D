using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{   
    public Animator animatorControl;
    public Transform player;
    public Rigidbody2D physics;
    public SpriteRenderer spritePlayer;

    public float speed = 2f;
    public float jumpForce = 2f;
    public bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (onGround && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        animatorControl.SetBool("IsFalling", !onGround && physics.velocity.y < 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            animatorControl.SetBool("IsJumping", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            physics.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onGround = false;
        }
    }
    void Move()
    {
        var move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (move != 0)
        {
            player.Translate(new Vector2(move, 0));

            if (move > 0)
            {
                Flip(false);
            }
            else if (move < 0)
            {
                Flip(true);
            }
        }
        
        animatorControl.SetBool("IsRunning", move != 0);
    }

    public void Flip(bool canFlip)
    {
        spritePlayer.flipX = canFlip;
    }
}

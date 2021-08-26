using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Froggy : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLength = 10f;
    [SerializeField] private float jumpHeight = 15f;

    private bool facingLeft = true;
    private Collider2D colli;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask ground;
    private Animator anim;

    private void Start()
    {
        colli = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        //FrogMove();    // Transitons from jump to fall and fall to idle
        if (anim.GetBool("FrogJump"))
        {
            if(rb.velocity.y < .1f)
            {
                anim.SetBool("FrogJump", false);
                anim.SetBool("FrogFalling", true);
            }
        }
        else if (colli.IsTouchingLayers(ground))
        {
            anim.SetBool("FrogFalling", false);
            anim.SetBool("FrogJump", false);
        }
        /*else
        {
            anim.SetBool("FrogJump", false);
            anim.SetBool("FrogFalling", false);
        }*/
    }

    private void FrogMove()
    {
        if (facingLeft)
        {
            if (transform.localScale.x != 1)
            {
                transform.localScale = new Vector3(1, 1);
            }

            //test to see if it is beyond leftcap
            if (transform.position.x > leftCap && facingLeft)
            {
                //test to see if frog then jump
                if (colli.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("FrogJump", true);
                    //anim.SetBool("FrogFalling", false);
                }

            }
            //if not then we are facing right
            else
            {
                facingLeft = false;
            }
        }

        else
        {
            if (transform.localScale.x != -1)
            {
                transform.localScale = new Vector3(-1, 1);
            }
            if (transform.position.x < rightCap)
            {
                //test to see if frog then jump
                if (colli.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("FrogJump", true);
                    //anim.SetBool("FrogFalling", false);
                }

            }
            else
            {
                facingLeft = true;
            }
        }
    }
    public void jumpedOn()
    {
        anim.SetTrigger("Death");
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
}

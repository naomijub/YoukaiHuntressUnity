using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb2d;
    Animator anim;

    bool isJumping = false;
    bool facingRight = true;
    bool isAttacking = false;
    float timer = 0.0f;

    public float speed = 4.0f;
    public float jumpTime = 0.5f;

    void Awake() {
        anim = GetComponent<Animator>();
    }

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {

        float h = Input.GetAxis("Horizontal");

        if (!isAttacking)
        {
            rb2d.velocity = new Vector2(h * speed, 0);
            WalkAnimationController(h);

            if (h > 0 && !facingRight)
            {
                Flip();
            }
            else if (h < 0 && facingRight)
            {
                Flip();
            }
            Jump();
        }

        AttackAnimationColtroller();
        
	}

    private void AttackAnimationColtroller()
    {
        if (Input.GetKey(KeyCode.Space) && !isAttacking) {
            anim.SetTrigger("Attack");
            isAttacking = true;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("IdleAnim")) {
            isAttacking = false;
        }
    }

    private void WalkAnimationController(float h)
    {
        if (h != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else {
            anim.SetBool("isWalking", false);
        }
    }

    private void Jump()
    {
        if (!isJumping)
        {
            float v = Input.GetAxis("Vertical");
            if (v > 0.0f)
            {
                rb2d.velocity += new Vector2(0, 4.0f);
                isJumping = true;
            }
        }
        else {
            timer += Time.deltaTime;
            if (timer >= jumpTime && isJumping)
            {
                isJumping = false;
                timer = 0.0f;
            }
            else {
                rb2d.velocity += new Vector2(0, 4.0f);
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

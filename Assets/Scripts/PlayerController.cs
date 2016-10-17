using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb2d;
    bool facingRight = true;

    public float speed = 4.0f;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float h = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(h * speed, 0);

        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight) {
            Flip();
        }
        Jump();
	}

    private void Jump()
    {
        float v = Input.GetAxis("Vertical");
        if (v > 0.0f) {
            Debug.Log("Jump");
            rb2d.velocity += new Vector2(0, 4.0f);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Toaster : Robot
{   
    private bool isGrounded = true;
    void Awake() {
        this.sr = GetComponent<SpriteRenderer>();
        this.rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb);
    }
    public override void Action() {
        if (isGrounded && Vector2.Dot(transform.up,Vector2.up) > 0.5f )
        {
            rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
            isGrounded = false;
            Debug.Log("Toaster Action");
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if collision with a platform
        if (collision.gameObject.tag.Equals("platform"))
        {
            isGrounded = true;
        } 
    }
}

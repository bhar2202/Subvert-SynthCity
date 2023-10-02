using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Toaster : Robot
{   
    private Vector2 bounceVector = new Vector2(0, 10);
    private bool isGrounded = true;
    void Awake() {
        this.sr = GetComponent<SpriteRenderer>();
        this.rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb);
    }
    public override void Action() {
        rb.AddForce(bounceVector, ForceMode2D.Impulse);
        Debug.Log("Toaster Action");
    }
}

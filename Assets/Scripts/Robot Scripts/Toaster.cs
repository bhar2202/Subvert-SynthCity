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
        rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
        Debug.Log("Toaster Action");
    }
}

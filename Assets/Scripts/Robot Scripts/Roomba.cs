using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Roomba : Robot
{
    private Vector2 bounceVector = new Vector2(0, 10);
    private bool isGrounded = true;
    void Awake()
    {
        this.sr = GetComponent<SpriteRenderer>();
        this.rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb);
    }
    public override void Action()
    {
        Debug.Log("Roomba Action");
    }
}
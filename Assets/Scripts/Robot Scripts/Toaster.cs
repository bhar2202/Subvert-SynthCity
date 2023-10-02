using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Toaster : Robot
{   
    void Awake() {
        this.sr = GetComponent<SpriteRenderer>();
    }
    public override void Action() {
        Debug.Log("Toaster Action");
    }
}

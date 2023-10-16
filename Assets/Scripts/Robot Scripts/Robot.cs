using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    // [SerializeField] private Sprite[] sprites;
    [SerializeField] private Sprite normal;
    [SerializeField] private Sprite possessed;

    private bool p = false;

    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public virtual void Possessed() {
        p = !p;
        switch(p) {
            case true:
                sr.sprite = possessed;
            break;
            case false:
                sr.sprite = normal;
            break;
        }
    }
    public virtual void Action() {
        Debug.Log("Robot Action");
    }
   
}

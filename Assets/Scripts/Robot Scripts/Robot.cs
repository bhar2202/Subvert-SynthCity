using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private bool p = false;

    public SpriteRenderer sr;
    public virtual void Possessed() {
        p = !p;
        switch(p) {
            case true:
                sr.sprite = sprites[1];
            break;
            case false:
                sr.sprite = sprites[0];
            break;
        }
    }
    public virtual void Action() {
        Debug.Log("Robot Action");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //var to get the character move and animate it
    public Rigidbody2D body;
    public SpriteRenderer spriterenderer;
    public void move(Vector2 direction, float walkSpeed)
    {
        body.velocity = direction * walkSpeed;
    }
}

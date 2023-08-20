using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //var to get the object of player
    private GameObject player;
    public SpriteRenderer spriterenderer;

    void Start(){
        player = GameObject.Find("Player");
    }
    public void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(-player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }

}

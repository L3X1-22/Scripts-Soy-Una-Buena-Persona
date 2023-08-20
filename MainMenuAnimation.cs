using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAnimation : MonoBehaviour
{
    public GameObject sprite1;
    public GameObject sprite2;
    private float time;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if(time >= speed){
            if (sprite1.activeSelf == true){
                sprite1.SetActive(false);
                sprite2.SetActive(true);
                time = 0f;
            } else {
                sprite1.SetActive(true);
                sprite2.SetActive(false);
                time = 0f;
            }
            
        }
    }
}

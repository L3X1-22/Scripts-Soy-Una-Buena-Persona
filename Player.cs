using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{

    //this var allows player to access inventory
    public bool inventoryAccess;

    //this var affects directly to history
    public int score;

    //var to get the character move and animate it
    public Rigidbody2D body;
    public SpriteRenderer spriterenderer;

    //sprites
    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;

    //var to modify the speed
    public float walkSpeed;

    //var to create raycast so player can interact with objects
    RaycastHit2D RcHit;
    public float distance;
    public LayerMask layerMask;
    
    //var to handle raycast hit
    Vector2 rayDirection = new Vector2(0,0);
    private bool collition;
    
    //var to interact with objects
    public List<string> inventory_Objects;
    private string lastPickedObject;
    Objects objectsMethods;

    //this method makes the character move, it have to be called every update
    private void playerMovement(){
        //set direction of movement
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;        

        if(direction.x != 0 || direction.y != 0){
            rayDirection = direction;
        }

        //set player velocity based on direction
        body.velocity = direction * walkSpeed;
    }

    
    //this method calls methods of objects using switch case
    private void callMethods(){
        Debug.Log(RcHit.collider.gameObject.tag.GetType());
        objectsMethods = RcHit.collider.gameObject.GetComponent<Objects>();
        switch(RcHit.collider.gameObject.tag){
            case "Agenda":
            
            //call method of object if "Fire1" pressed (modify in project settings)
            if(Input.GetButtonDown("Fire1")){
                objectsMethods.Agenda();

            }
            break;
        } 
    }
    
    //this method manages inventory
    private void inventoryManager(){
        //delete duplicated objects
        inventory_Objects = inventory_Objects.Distinct().ToList();

        //iter inventory objects just in case
        Debug.Log(inventory_Objects.Count);
    }

    //this function showsdebug raycast so you can see it in editor and calls methods
    private void raycastManager(){
        //create raycast
        RcHit = Physics2D.Raycast(gameObject.transform.position, rayDirection, distance, layerMask);

        //manage and raycast
        if(RcHit.collider != null){
            //show raycast in green if raycast hitted something
            Debug.DrawRay(gameObject.transform.position, rayDirection * distance, Color.green);

            //call method of object
            callMethods();
            //cleans inventory
            inventoryManager();

        } else {
            //show raycast in red if raycast is not hitting anything
            Debug.DrawRay(gameObject.transform.position, rayDirection * distance, Color.red);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        //make character move
        playerMovement();

         //start raycast functions
        raycastManager();
    }

    void FixedUpdate(){
        
    }
}

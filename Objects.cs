using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{

    //call call the dialogue manager
    DialogueManager dialogue;

    //this var calls the player script
    Player playerObject;

    //var so methods can return text
    private string itemReturned;
    private bool inPlayer = false;
  

    //aux variables
    private int lavarCount = 0;
    private int ropaCount = 0;
    private bool roperoAbierto = false;
    private bool roperoAbiertoE = false;

    //this method checks if the inventory is open 
    private void checkInventory(){

        //check if object isn't in player yet
        if(inPlayer == false){

            //iterate inventory_objects to check if itemReturned is in inventory
            foreach(var i in playerObject.inventory_Objects){
                
                //if itemReturned is in inentory we set inPlayer to true
                if(i == itemReturned){
                    inPlayer = true;
                }
            }
        }

        //if object is not in inventory we add it
        if(inPlayer == false){
            playerObject.inventory_Objects.Add(itemReturned);
            inPlayer = true;
        }
    }

    void Start (){
        //get the player object in unity
        playerObject = GameObject.Find("Player").GetComponent<Player>();
        dialogue = GameObject.Find("DialogueText").GetComponent<DialogueManager>();
    }

    public void Agenda(){
        
        //first thing to do in every method is to write what the item should return if needed
        itemReturned = "llaveDormitorio";

        //second thing in every method is what the item should do, eather grant access to inventory or what ever it should do
        //TODO: Mostrar cosas por hacer
        agendaObject.TriggerDialogue();
        playerObject.inventoryAccess = true;
        

        Debug.Log("Asd");

        dialogue.changeText(1);


        //third and last thing to do is call checkInventory() so we can add the item to inventory if needed 
        checkInventory();
    }


    //individual methods for every kind of object

    public void Cama(bool espejo)
    {
        if(!espejo)
        {

        }
        else
        {
            
        }
    }


    public void Ropero(bool espejo)
    {
        if (!espejo)
        {

        }
        else
        {

        }
    }

    public void PrendaVieja()
    {

    }

    public void Ropa()
    {

    }

    public void PuertaDormitorio()
    {

    }

    public void PuertasSala()
    {

    }

    public void JuegoLlaves() 
    {
        itemReturned = "JuegoLlaves";

        checkInventory();
    }

    public void LlaveReloj()
    {
        itemReturned = "LlaveReloj";

        checkInventory();
    }

    public void Reloj(bool espejo)
    {
        if (!espejo)
        {

        }
        else
        {

        }
    }

    public void Balde(bool espejo)
    {
        if (!espejo)
        {

        }
        else
        {

        }
    }

    public void Trapo()
    {
        itemReturned = "Trapo";

        checkInventory();
    }

    public void Pintura(bool espejo)
    {
        if (!espejo)
        {

        }
        else
        {

        }
    }

    public void Cuadro(bool espejo)
    {
        if (!espejo)
        {

        }
        else
        {

        }
    }

    public void Televisor(bool espejo)
    {
        if (!espejo)
        {

        }
        else
        {

        }
    }

    public void Salida(bool espejo)
    {
        if (!espejo)
        {

        }
        else
        {

        }
    }

    public void Refrigerador(bool espejo)
    {
        if (!espejo)
        {

        }
        else
        {

        }
    }

    public void Lavadero(bool espejo)
    {
        if (!espejo)
        {

        }
        else
        {

        }
    }

    public void Inodoro(bool espejo)
    {
        if (!espejo)
        {

        }
        else
        {

        }
    }

    public void Botella(bool espejo)
    {
        if (!espejo)
        {

        }
        else
        {

        }
    }

    public void Suciedad()
    {

    }

    public void Cesto(bool espejo)
    {
        if (!espejo)
        {

        }
        else
        {

        }
    }
}

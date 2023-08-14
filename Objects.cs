using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{

    //call call the dialogue manager
    public DialogueManager dialogue;

    //this var calls the player script
    Player playerObject;

    //var so methods can return text
    private string itemReturned;
    private bool inPlayer = false;
  

    //aux variables
    private int lavarCount = 0;
    private int ropaCount = 0;
    private int limpioCount = 0;
    private int TaskCount = 0;
    private bool camaTendida=false;
    private bool camaTendidaE = false;
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

    private void dropItem(string name)
    {
        if (playerObject.inventory_Objects.Contains(name)) 
        {
            playerObject.inventory_Objects.Remove(name);     
        }
    }

    void Start (){
        //get the player object in unity
        playerObject = GameObject.Find("Player").GetComponent<Player>();
        dialogue = GameObject.Find("DialogueText").GetComponent<DialogueManager>();
        dialogue.gameObject.SetActive(false);
    }

    void Update(){
        
    }
    

    //individual methods for every kind of object
    public void Agenda()
    {
        itemReturned = "llaveDormitorio";
        playerObject.inventoryAccess = true;
        StartCoroutine(dialogue.showText(0, 2));
        checkInventory();
        dialogue.tag = "Agenda";
    }


    public void Cama(bool espejo)
    {
        if(!espejo)
        {
            if(!camaTendida)
            {
                StartCoroutine(dialogue.showText(0,2));
                //Opcion A) Tenderla ahora, B) Mas tarde
                //A)
                StartCoroutine(dialogue.showText(0,2));
                camaTendida = true;
            }
            else
            {
                StartCoroutine(dialogue.showText(0,2));
            }

        }
        else
        {
            if (!camaTendidaE)
            {
                StartCoroutine(dialogue.showText(0,2));
                //Opcion A) Tenderla ahora, B) Echarse a dormir, C) Mas tarde
                //A)
                StartCoroutine(dialogue.showText(0,2));
                playerObject.score += 1;
                camaTendidaE = true;
                //B)
                StartCoroutine(dialogue.showText(0,2));
                playerObject.score -= 2;
            }
            else
            {
                StartCoroutine(dialogue.showText(0,2));
            }
        }

        //Completar tarea
    }


    public void Ropero(bool espejo)
    {
        if (!espejo)
        {
            if(!roperoAbierto)
            {
                StartCoroutine(dialogue.showText(0,2));
                //Opcion A) Abrir B) Salir
            }
            else
            {
                StartCoroutine(dialogue.showText(0,2));
                itemReturned = "prendaVieja";
            }
        }
        else
        {
            if (!roperoAbiertoE)
            {
                StartCoroutine(dialogue.showText(0,2));
                //Opcion A) Abrir B) Salir
            }
            else
            {
                StartCoroutine(dialogue.showText(0,2));
                itemReturned = "llaveReloj";
            }
        }
    }


    public void Ropa()
    {
        StartCoroutine(dialogue.showText(0,2));
        ropaCount++;
        //Opcion A) Agarrar, B) salir
        itemReturned = "ropa" + ropaCount;
    }

    public void PuertaDormitorio()
    {
        if (!playerObject.inventory_Objects.Contains("llaveDormitorio"))
        {
            StartCoroutine(dialogue.showText(0,2));
        }
        else
        {
            //abrir puerta
        }
    }

    public void PuertasSala()
    {
        if (!playerObject.inventory_Objects.Contains("juegoLlaves"))
        {
            StartCoroutine(dialogue.showText(0,2));
        }
        else
        {
            //abrir puerta
        }
    }

    public void JuegoLlaves() 
    {
        itemReturned = "juegoLlaves";
        StartCoroutine(dialogue.showText(0,2));
        checkInventory();
    }

    public void LlaveReloj()
    {
        itemReturned = "llaveReloj";
        StartCoroutine(dialogue.showText(0,2));
        checkInventory();
    }

    public void Reloj(bool espejo)
    {
        if (!espejo)
        {
            if(!playerObject.inventory_Objects.Contains("llaveReloj"))
            {
                StartCoroutine(dialogue.showText(0,2));
            }
            else
            {
                StartCoroutine(dialogue.showText(0,2));
                //Opcion A) Pararlo B) No hacer nada
                //A)
                playerObject.score -= 1;
            }
        }
        else
        {
            if (!playerObject.inventory_Objects.Contains("llaveReloj"))
            {
                StartCoroutine(dialogue.showText(0,2));
            }
            else
            {
                StartCoroutine(dialogue.showText(0,2));
                //Opcion A) Darle cuerda B) No hacer nada
                //A)
                playerObject.score += 1;
            }
        }
    }

    public void Balde(bool espejo)
    {
        if (!espejo)
        {
            if (!playerObject.inventory_Objects.Contains("Trapo"))
            {
                StartCoroutine(dialogue.showText(0,2));
            }
            else
            {
                StartCoroutine(dialogue.showText(0,2));
                //Opcion A) Mojar el Trapo B) No hacer nada
                itemReturned = "TrapoMojado";
                checkInventory();
            }
        }
        else
        {
            if (!playerObject.inventory_Objects.Contains("Trapo"))
            {
                StartCoroutine(dialogue.showText(0,2))
            }
            else
            {
                StartCoroutine(dialogue.showText(0,2))
                //Opcion A) Mojar el Trapo B) No hacer nada
                itemReturned = "TrapoTurbio";
                checkInventory();
            }
           
        }
    }

    public void Trapo()
    {
        StartCoroutine(dialogue.showText(0,2))
        itemReturned = "Trapo";
        checkInventory();
    }

    public void Pintura(bool espejo)
    {
        if (!espejo)
        {
            StartCoroutine(dialogue.showText(0,2))
            //Opcion A) Descolgar B) No hacer nada
        }
        else
        {
            if (!playerObject.inventory_Objects.Contains("Pintura"))
            {
                StartCoroutine(dialogue.showText(0,2))
            }
            else
            {
                StartCoroutine(dialogue.showText(0,2))
                //Opcion A) Colgar la Pintura B) No hacer nada
                //A)
                playerObject.score += 1;
            }
        }
    }

    public void Cuadro(bool espejo)
    {
        if (!espejo)
        {
            StartCoroutine(dialogue.showText(0,2))
        }
        else
        {
            StartCoroutine(dialogue.showText(0,2))
        }
    }

    public void Televisor(bool espejo)
    {
        if (!espejo)
        {
            StartCoroutine(dialogue.showText(0,2))
        }
        else
        {
            StartCoroutine(dialogue.showText(0,2))
        }
    }

    public void Salida(bool espejo)
    {
        if (!espejo)
        {
            StartCoroutine(dialogue.showText(0,2))
        }
        else
        {
            StartCoroutine(dialogue.showText(0,2))
        }
    }

    public void Refrigerador(bool espejo)
    {
        if (!espejo)
        {
            StartCoroutine(dialogue.showText(0,2))
        }
        else
        {
            StartCoroutine(dialogue.showText(0,2))
        }
    }

    public void Lavadero(bool espejo)
    {
        if (!espejo)
        {
            StartCoroutine(dialogue.showText(0,2))
        }
        else
        {
            StartCoroutine(dialogue.showText(0,2))
        }
    }

    public void Inodoro(bool espejo)
    {
        if (!espejo)
        {
            StartCoroutine(dialogue.showText(0,2))
        }
        else
        {
            StartCoroutine(dialogue.showText(0,2))
        }
    }

    public void Botella(bool espejo)
    {
        if (!espejo)
        {
            StartCoroutine(dialogue.showText(0,2))
            //Opcion A) Beber B) No hacer nada
            playerObject.score -= 1;
        }
        else
        {
            StartCoroutine(dialogue.showText(0,2))
            //Opcion A) Beber B) No hacer nada
            playerObject.score += 1;
        }
    }

    public void Suciedad()
    {
        //Opcion A) Limpiar B) No hacer nada
        if (playerObject.inventory_Objects.Contains("TrapoMojado"))
        {
            StartCoroutine(dialogue.showText(0,2))
            limpioCount++;
        }
    }

    public void Cesto(bool espejo)
    {
        if (!espejo)
        {
            if (playerObject.inventory_Objects.Contains("PrendaVieja"))
            {
                StartCoroutine(dialogue.showText(0,2))
                //Opcion A) Tirar B) No hacer nada
                //A)
                playerObject.score -= 1;
            }

            if (playerObject.inventory_Objects.Contains("Pintura"))
            {
                StartCoroutine(dialogue.showText(0,2))
                //Opcion A) Tirar B) No hacer nada
                //A)
                playerObject.score -= 1;
            }


        }
        else
        {
            StartCoroutine(dialogue.showText(0,2))
        }
    }
}

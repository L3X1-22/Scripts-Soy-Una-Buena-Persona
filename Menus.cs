using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour{

    public GameObject pauseMenu;
    public GameObject agendaMenu;
    public GameObject HUD;

    private bool pauseActive = false;
    private bool agendaActive = false;

    public float timeBetweenActions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause") && pauseActive == false && agendaActive == false){
            pause();
        } else if (Input.GetButtonDown("Pause") && pauseActive == true){
            resume();
        }

        if(Input.GetButtonDown("Agenda Menu") && pauseActive == false && agendaActive == false){
            openAgenda();
        } else if(Input.GetButtonDown("Agenda Menu") && agendaActive == true || Input.GetButtonDown("Pause") && agendaActive == true){
            closeAgenda();
        }

        timeBetweenActions = timeBetweenActions * Time.deltaTime; 
        Debug.Log(timeBetweenActions);
    }

    void FixedUpdate(){
        
    }

    public void pause(){
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        agendaMenu.SetActive(false);
        HUD.SetActive(false);
        pauseActive = true;
        timeBetweenActions = 0f;
    }

    public void resume(){
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        agendaMenu.SetActive(false);
        HUD.SetActive(true);
        pauseActive = false;
        timeBetweenActions = 0f;
    }

    public void openAgenda(){
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(false);
        agendaMenu.SetActive(true);
        HUD.SetActive(false);
        agendaActive = true;
        timeBetweenActions = 0f;
    }

    public void closeAgenda(){
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        agendaMenu.SetActive(false);
        HUD.SetActive(true);
        agendaActive = false;
        timeBetweenActions = 0f;
    }
}

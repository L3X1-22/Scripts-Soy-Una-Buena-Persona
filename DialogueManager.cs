using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class DialogueManager : MonoBehaviour
{

    public string tag;

    //this var contains necesary info for csv dialogues
    private static string dialoguePath = "/CSVtext/dialogues.csv";
    List<string> spreadedDialogues = new List<string>();
    public TextMeshProUGUI Text;
    
    // Start is called before the first frame update
    void Start(){
        //get dialogues from a CSV
        string[] allDialogues = File.ReadAllLines(Application.dataPath + dialoguePath);
        foreach(string strings in allDialogues){
            //Debug.Log(strings);
            spreadedDialogues.Add(strings);
        }
        //Debug.Log(spreadedDialogues.Count);
    }

    // Update is called once per frame
    void Update(){
        
    }


    private void changeText(int dialogue){
        Text.text = spreadedDialogues[dialogue];
    }

    private IEnumerator WaitForKeyPress(KeyCode Key){
    bool done = false;
    while (!done){ // essentially a "while true", but with a bool to break out naturally

        if (Input.GetKeyDown(Key)){

            done = true; // breaks the loop
        }
        yield return null; // wait until next frame, then continue execution from here (loop continues)
    }

        // now this function returns
    }

    public IEnumerator showText(int indexPrimera, int cantidad)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        for(int i = 0; i < cantidad; i++){
            changeText(indexPrimera);
            indexPrimera ++;
            // wait for player to press space
            yield return WaitForKeyPress(KeyCode.Space); // wait for this function to return
        }
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        Destroy(GameObject.FindWithTag(tag));

    }
}

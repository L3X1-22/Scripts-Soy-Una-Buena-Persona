using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class DialogueManager : MonoBehaviour
{

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

    public void changeText(int dialogue){
        Text.text = spreadedDialogues[dialogue];
    }
}

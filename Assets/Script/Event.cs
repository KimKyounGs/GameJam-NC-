using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{  
    public static Event instance;
    
    public People NPC = new People();

    public int NPCID;

    void Start()
    {   
        instance = this;
    }

    public void StartEvent()
    {
        Dialogue[] dialogues = DataBaseManager.instance.GetDialogues(NPCID);
        DialogueManager.instance.ShowDialogue(dialogues);
        Pear.instance.BeLifesaving();

        Destroy(gameObject);
    }


}

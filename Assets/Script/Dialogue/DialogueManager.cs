using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [Header("Text Print Delay")]
    [SerializeField] float textDelay;

    Dialogue[] dialogues;

    [SerializeField] GameObject dialogueBox;
    [SerializeField] Text textDialogue;
    [SerializeField] Text textName;

    int lineCount = 0; // 대화 카운트.
    int contextCount = 0; // 대사 카운트.

    bool isDialogue;
    

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        StartDialogue();
    }

    void StartDialogue()
    {
        if (isDialogue) 
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {

                if (dialogues != null)
                {
                    if (++contextCount < dialogues[lineCount]._contexts.Length)
                    {
                        StartCoroutine(TypeContext());
                    }
                    else
                    {
                        if(++lineCount < dialogues.Length)
                        {
                            StartCoroutine(TypeContext());
                        }
                        else 
                        {
                            EndDialogue();
                        }
                    }
                }
            }
        }
    }

    public void ShowDialogue(Dialogue[] p_dialogues)
    {
        isDialogue = true;
        textDialogue.text = "";
        textName.text = "";
        dialogues = p_dialogues;
        GameBase._bShipMove = false;
        StartCoroutine(TypeContext());
    }

    public void EndDialogue()
    {
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        GameBase._bShipMove = true;
        SettingUI(false);
    
    }

    IEnumerator TypeContext()
    {

        // 대화가 t_ReplaceText에 한줄한줄씩 들어옴.
        string ReplaceText = null;
        if (dialogues != null)
        {
            ReplaceText = dialogues[lineCount]._contexts[contextCount]; // ex) 다른 문자를 쉼표로 바꿔주는 역할.
        }

        ReplaceText = ReplaceText.Replace("'", ","); // 문자 "'"가 ","로 바뀜

        // 메인 대화.
        if (dialogues != null) 
        {
            /*
            // 퀘스트 진행
            if (dialogues[lineCount].questId != "")
            {
                // Debug.Log("Quest Inside");
                int questId = int.Parse(dialogues[lineCount].questId);
                QuestManager.questId = questId;
                // Debug.Log(questId);
            }
            */
            SettingUI(true);
            /*
            bool t_white = false, t_red = false;
            bool t_ignore = false;
            */
            for (int i = 0; i < ReplaceText.Length; i++)
            {
                string tLetter = ReplaceText[i].ToString();
                textDialogue.text += tLetter;
                /*
                switch (t_ReplaceText[i])
                {
                    case '○': t_white = true; t_red = false; t_ignore = true; break;
                    case '●': t_white = false; t_red = true; t_ignore = true; break;
                }

                string t_letter = t_ReplaceText[i].ToString();
                */
                /*
                if (!t_ignore)
                {
                    if (t_white) { t_letter = "<color=#ffffff>" + t_letter + "</color>"; }
                    else if (t_red) { t_letter = "<color=#ff0000>" + t_letter + "</color>"; }
                    txt_Dialogue.text += t_letter;
                }
                t_ignore = false;
                */
                yield return new WaitForSeconds(textDelay);
                }
            } 
        }
    

    void SettingUI(bool pFlag)
    {
        dialogueBox.SetActive(pFlag);
    
        if (pFlag)
        {
            textName.text = dialogues[lineCount]._characterName;
        }
    }

}
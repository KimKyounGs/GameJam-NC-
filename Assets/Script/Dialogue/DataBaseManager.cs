using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;
    [SerializeField] string csvFileName;
    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();

    Dictionary<int, Dictionary<int, Dialogue>> dialogueEventDic = new Dictionary<int, Dictionary<int, Dialogue>>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DialogueParser theParser = GetComponent<DialogueParser>();
            // 모든 대화 내용이 Parse함수를 실행하고 나서 dialogues변수에 담긴다.
            Dialogue[] dialogues;
            dialogues = theParser.Parse(csvFileName);
            // 그리고 dilogueDic에 (줄,내용) 이런식으로 저장.
            for (int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }

        }
    }
}

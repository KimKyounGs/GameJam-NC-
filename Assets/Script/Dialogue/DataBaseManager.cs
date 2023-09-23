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
            // ��� ��ȭ ������ Parse�Լ��� �����ϰ� ���� dialogues������ ����.
            Dialogue[] dialogues;
            dialogues = theParser.Parse(csvFileName);
            // �׸��� dilogueDic�� (��,����) �̷������� ����.
            for (int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }

        }
    }
}

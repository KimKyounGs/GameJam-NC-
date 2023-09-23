using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFilieName)
    {
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFilieName); // CSV �����͸� �ޱ� ���� �׸� 
        List<Dialogue> dialgoueList = new List<Dialogue>(); // ��� ����Ʈ ����


        string[] data = csvData.text.Split(new char[] { '\n' }); //���͸� ������ �ɰ��� ����
        //���͸� ������ data[0] - ������Ʈ�� �� 1��° �� �ǹ� 

        for (int i = 1; i < data.Length;) // i++�� ���� ������ �״��� ������ ���ǹ��� ���ؼ� 
        {
            string[] row = data[i].Split(new char[] { ',' }); // , ������ row �ٿ� ����
            
            Dialogue dialogue = new Dialogue(); // ��� ����Ʈ ����
            dialogue._ID = int.Parse(row[0]);
            dialogue._characterName = row[1];
            if (row[3] != " ") {
                dialogue._fontSize = int.Parse(row[3]);
            }
            if (row[4] != " " ) {
                dialogue._fontColor = int.Parse(row[4]);
            }
            dialogue._sprite = row[5];
            dialogue._music = row[6];

            List<string> contextList = new List<string>(); // ��� ����Ʈ ����

            //List<string> SkipList = new List<string>(); // ���� �ǳ��� ��� �߰� ���ϸ� ������

            //dialgoue.contexts = row[2]; // �迭�� ũ�⸦ �̸� ��������ߵǴµ� ������ �ְ��־ �� ����Ʈ�� �̿�
            do
            {
                contextList.Add(row[2]);
                if (++i < data.Length) // i�� �̸� ������ ���¿��� �����ش� data.Length���� �۴ٸ�
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }

            } while (row[1].ToString() == ""); // ���� 1ȸ ���� �� ���� �� ���� �����Ű�� ���ǹ��� ��
                                               // row 0��° �ٿ��� ID�� �� �ְ� Tostring���� �� �������� ������


            dialogue._contexts = contextList.ToArray();

            dialgoueList.Add(dialogue);

            // GameObject obj = GameObject.Find("DialgoueManager");

        }

        
        return dialgoueList.ToArray();
        
    }
}

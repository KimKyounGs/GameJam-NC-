using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFilieName)
    {
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFilieName); // CSV 데이터를 받기 위한 그릇 
        List<Dialogue> dialgoueList = new List<Dialogue>(); // 대사 리스트 생성


        string[] data = csvData.text.Split(new char[] { '\n' }); //엔터를 만나면 쪼개어 넣음
        //엔터를 만났다 data[0] - 엑셀시트의 맨 1번째 줄 의미 

        for (int i = 1; i < data.Length;) // i++는 대한 내용은 그다음 내용은 조건문을 통해서 
        {
            string[] row = data[i].Split(new char[] { ',' }); // , 단위로 row 줄에 저장
            
            Dialogue dialogue = new Dialogue(); // 대사 리스트 생성
            dialogue._ID = int.Parse(row[0]);
            dialogue._characterName = row[1];
            if (row[3] != "") {
                dialogue._fontSize = int.Parse(row[3]);
            }
            if (row[4] != "" ) {
                dialogue._fontColor = int.Parse(row[4]);
            }
            dialogue._sprite = row[5];
            dialogue._music = row[6];

            List<string> contextList = new List<string>(); // 대사 리스트 생성

            //List<string> SkipList = new List<string>(); // 엑셀 맨끝줄 비고 추가 안하면 오류남

            //dialgoue.contexts = row[2]; // 배열의 크기를 미리 지정해줘야되는데 강제로 넣고있어서 위 리스트를 이용
            do
            {
                contextList.Add(row[2]);
                if (++i < data.Length) // i가 미리 증가한 상태에서 비교해준다 data.Length보다 작다면
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }

            } while (row[1].ToString() == ""); // 최초 1회 조건 비교 없이 한 차례 실행시키고 조건문을 비교
                                               // row 0번째 줄에는 ID가 들어가 있고 Tostring으로 빈 공간인지 비교해줌


            dialogue._contexts = contextList.ToArray();

            dialgoueList.Add(dialogue);

            // GameObject obj = GameObject.Find("DialgoueManager");
            
        }

        
        return dialgoueList.ToArray();
        
    }
}

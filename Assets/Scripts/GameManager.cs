using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Question;                                   //问题文本框
    public Text Answer;                                     //答案文本框
    public Text QaText;                                     //显示对错
    public static List<string> SList;                       //接收问题
    private int _answer;                                    //答案
    void Awake()
    {
        _answer = 0;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomWord()
    {
        int num = Random.Range(1, 5);
        _answer = num;
        SList = Dictionaries.WordDic[_answer].Translation;
        Question.text = null;
        foreach (var s in SList)
        {
            Question.text += s;
        }
    }

    public void AnswerWord()
    {
        if (Answer.text== Dictionaries.WordDic[_answer].Name)
        {
            Question.text = Dictionaries.WordDic[_answer].Name;
            
            foreach (var w in Dictionaries.WordDic[_answer].Translation)
            {
                Question.text += "\n" + w;
            }
            Question.text += "\n" + "单词变形";
            foreach (var w in Dictionaries.WordDic[_answer].Deformation)
            {
                Question.text += "\n" + w;
            }

            QaText.text = "√";
        }
        else
        {
            QaText.text = "×";
        }
    }
}

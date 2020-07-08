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

    //随机单词题目
    public void RandomWord()
    {
        QaText.text = null;
        int num = Random.Range(1, Dictionaries.WordDic.Count+1);
        _answer = num;
        SList = Dictionaries.WordDic[_answer].Translation;
        Question.text = null;
        foreach (var s in SList)
        {
            Question.text += s;
        }
    }

    //回答问题按钮，判断答案是否正确
    public void AnswerWord()
    {
        if (_answer != 0)
        {
            if (Answer.text == Dictionaries.WordDic[_answer].Name)
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

    //跳转到记单词页面

}

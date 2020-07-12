using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//改变单词控制器
public class UpDateWord : MonoBehaviour
{
    public Text InputText;                                  //输入框

    public GameObject Content;                              //显示框

    public GameObject Word;                                 //单词预制体

    private string _contrast;                               //对比，判断输入框是否有变化

    public GameObject UpdateGameObject;                     //修改页面

    public GameObject SeGameObject;                         //选择单词页面
    // Start is called before the first frame update
    void Start()
    {
        _contrast = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputText.text.Length!=0)
        {
            if (_contrast != InputText.text)
            {
                _contrast = InputText.text;
                Clear();
                for (int i = 1; i < Dictionaries.WordDic.Count + 1; i++)
                {
                    if (Dictionaries.WordDic[i].Name.Contains(InputText.text))
                    {
                        GameObject obj = Instantiate(Word);
                        obj.transform.SetParent(Content.transform);
                        obj.GetComponent<Text>().text = Dictionaries.WordDic[i].Name;
                        obj.GetComponent<WordInformation>().Id = Dictionaries.WordDic[i].Id;
                        obj.GetComponent<WordInformation>().Name = Dictionaries.WordDic[i].Name;
                        obj.GetComponent<WordInformation>().Deformation = Dictionaries.WordDic[i].Deformation;
                        obj.GetComponent<WordInformation>().Translation = Dictionaries.WordDic[i].Translation;
                        obj.GetComponent<WordInformation>().InputText = InputText;
                        obj.GetComponent<WordInformation>().UpdateGameObject = UpdateGameObject;
                        obj.GetComponent<WordInformation>().Type = 2;
                        obj.GetComponent<WordInformation>().SeGameObject = SeGameObject;
                        obj.name = Dictionaries.WordDic[i].Name;
                    }
                }
            }
        }
        else
        {
            if (Content.transform.childCount!= Dictionaries.WordDic.Count)
            {
                Clear();
                for (int i = 1; i < Dictionaries.WordDic.Count + 1; i++)
                {
                    GameObject obj = Instantiate(Word);
                    obj.transform.SetParent(Content.transform);
                    obj.GetComponent<Text>().text = Dictionaries.WordDic[i].Name;
                    obj.GetComponent<WordInformation>().Id = Dictionaries.WordDic[i].Id;
                    obj.GetComponent<WordInformation>().Name = Dictionaries.WordDic[i].Name;
                    obj.GetComponent<WordInformation>().Deformation = Dictionaries.WordDic[i].Deformation;
                    obj.GetComponent<WordInformation>().Translation = Dictionaries.WordDic[i].Translation;
                    obj.GetComponent<WordInformation>().InputText = InputText;
                    obj.GetComponent<WordInformation>().UpdateGameObject = UpdateGameObject;
                    obj.GetComponent<WordInformation>().Type = 2;
                    obj.GetComponent<WordInformation>().SeGameObject = SeGameObject;
                    obj.name = Dictionaries.WordDic[i].Name;
                }
            }
        }
    }

    //清空下拉框
    private void Clear()
    {
        for (int i = 0; i < Content.transform.childCount; i++)
        {
            Destroy(Content.transform.GetChild(i).gameObject);
        }
    }
}

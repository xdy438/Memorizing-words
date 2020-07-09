using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//删除单词功能
public class Del : MonoBehaviour
{
    public Text InputText;                                      //输入框文本

    public GameObject Frames;                                   //下拉框

    private GameObject _content;                                //容器

    public GameObject PreText;                                  //文本预制体

    private string _contrast;                                   //对比，判断输入框是否有变化

    public Text Introduce;                                      //介绍文本

    public static int Id;

    public static string Name;

    public static List<string> Translation = new List<string>();           //翻译

    public static List<string> Deformation = new List<string>();           //单词变形

    // Start is called before the first frame update
    void Start()
    {
        _contrast = null;
        _content = Frames.transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputText.text.Length!=0)
        {
            if (_contrast!= InputText.text)
            {
                _contrast = InputText.text;
                Frames.SetActive(true);
                Clear();
                //将模糊查询结果放入到下拉框中
                for (int i = 1; i < Dictionaries.WordDic.Count + 1; i++)
                {
                    if (Dictionaries.WordDic[i].Name.Contains(InputText.text))
                    {
                        GameObject obj = Instantiate(PreText);
                        obj.transform.SetParent(_content.transform);
                        obj.GetComponent<Text>().text = Dictionaries.WordDic[i].Name;
                        obj.GetComponent<WordInformation>().Id = Dictionaries.WordDic[i].Id;
                        obj.GetComponent<WordInformation>().Name = Dictionaries.WordDic[i].Name;
                        obj.GetComponent<WordInformation>().Deformation = Dictionaries.WordDic[i].Deformation;
                        obj.GetComponent<WordInformation>().Translation = Dictionaries.WordDic[i].Translation;
                        obj.GetComponent<WordInformation>().InputText = InputText;
                        Debug.Log(1);
                    }
                }

                //如果没有则隐藏下拉框
                if (_content.transform.childCount==0)
                {
                    Frames.SetActive(false);
                }

                //如果搜出想要的则隐藏下拉框
                if (InputText.text== _content.transform.GetChild(0).GetComponent<Text>().text)
                {
                    Debug.Log(1222);
                    //TODO 显示单词信息
                    Id = _content.transform.GetChild(0).GetComponent<WordInformation>().Id;
                    Name = _content.transform.GetChild(0).GetComponent<WordInformation>().Name;
                    Translation = _content.transform.GetChild(0).GetComponent<WordInformation>().Translation;
                    Deformation = _content.transform.GetChild(0).GetComponent<WordInformation>().Deformation;
                    Introduce.text = Name;
                    foreach (var t in Translation)
                    {
                        Introduce.text += "\n" + t;
                    }

                    foreach (var d in Deformation)
                    {
                        Introduce.text += "\n" + d;
                    }

                    Frames.SetActive(false);
                }
            }
        }
        else
        {
            Frames.SetActive(false);
        }
    }

    //清空下拉框
    private void Clear()
    {
        for (int i = 0; i < _content.transform.childCount; i++)
        {
            Destroy(_content.transform.GetChild(i).gameObject);
        }
    }
}

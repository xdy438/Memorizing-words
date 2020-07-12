using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;

//单词修改
public class DataWord : MonoBehaviour
{
    public int Id;                                                  //单词ID

    public string Name;                                             //单词名字

    public List<string> Translation = new List<string>();           //翻译

    public List<string> Deformation = new List<string>();           //单词变形

    public GameObject SeGameObject;                                 //选择单词页面

    public GameObject WordGameObject;                               //单词输入框

    public GameObject[] TrGameObjects;                              //翻译输入框

    public GameObject[] DefGameObjects;                             //变形输入框
    // Update is called once per frame
    void Update()
    {
        
    }

    //显示单词信息
    public void Show()
    {
        WordGameObject.GetComponent<InputField>().text = Name;

        foreach (var t in Translation)
        {
            string[] str = t.Split('.');
            switch (str[0])
            {
                case "v":
                    TrGameObjects[0].GetComponent<InputField>().text = str[1];
                    break;
                case "n":
                    TrGameObjects[1].GetComponent<InputField>().text = str[1];
                    break;
                case "adj":
                    TrGameObjects[2].GetComponent<InputField>().text = str[1];
                    break;
                case "adv":
                    TrGameObjects[3].GetComponent<InputField>().text = str[1];
                    break;
                case "vt":
                    TrGameObjects[4].GetComponent<InputField>().text = str[1];
                    break;
                case "vi":
                    TrGameObjects[5].GetComponent<InputField>().text = str[1];
                    break;
            }
        }


        for (int i = 1; i < Deformation.Count; i++)
        {
            string[] str = Deformation[i].Split(' ');
            switch (str[0])
            {
                case "复数":
                    DefGameObjects[0].GetComponent<InputField>().text = str[2];
                    break;
                case "第三人称单数":
                    DefGameObjects[1].GetComponent<InputField>().text = str[2];
                    break;
                case "现在分词":
                    DefGameObjects[2].GetComponent<InputField>().text = str[2];
                    break;
                case "过去式":
                    DefGameObjects[3].GetComponent<InputField>().text = str[2];
                    break;
                case "过去分词":
                    DefGameObjects[4].GetComponent<InputField>().text = str[2];
                    break;
                case "形容词":
                    DefGameObjects[5].GetComponent<InputField>().text = str[2];
                    break;
                case "比较级":
                    DefGameObjects[6].GetComponent<InputField>().text = str[2];
                    break;
                case "最高级":
                    DefGameObjects[7].GetComponent<InputField>().text = str[2];
                    break;
            }
        }

    }

    //返回
    public void GetBack()
    {
        SeGameObject.SetActive(true);
        WordGameObject.GetComponent<InputField>().text = null;
        foreach (var t in TrGameObjects)
        {
            t.GetComponent<InputField>().text = null;
        }

        foreach (var d in DefGameObjects)
        {
            d.GetComponent<InputField>().text = null;
        }
        gameObject.SetActive(false);
    }

    public void UpdateWord()
    {

    }
}

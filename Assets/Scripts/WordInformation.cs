using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class WordInformation : MonoBehaviour
{
    public int Id;                                                  //单词ID

    public string Name;                                             //单词名字

    public List<string> Translation = new List<string>();           //翻译

    public List<string> Deformation = new List<string>();           //单词变形

    public Text InputText;                                          //输入框

    public int Type;                                                //单词状态

    public GameObject UpdateGameObject;                             //修改页面

    public GameObject SeGameObject;                                 //选择单词页面

    //点击单词
    public void Button()
    {
        switch (Type)
        {
            case 1:
                InputText.gameObject.GetComponentInParent<InputField>().text = Name;
                break;
            case 2:
                UpdateGameObject.SetActive(true);
                UpdateGameObject.GetComponent<DataWord>().Id = Id;
                UpdateGameObject.GetComponent<DataWord>().Name = Name;
                UpdateGameObject.GetComponent<DataWord>().Deformation = Deformation;
                UpdateGameObject.GetComponent<DataWord>().Translation = Translation;
                UpdateGameObject.GetComponent<DataWord>().Show();
                SeGameObject.SetActive(false);
                break;
        }

    }
}

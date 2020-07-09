using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordInformation : MonoBehaviour
{
    public int Id;                                                  //单词ID

    public string Name;                                             //单词名字

    public List<string> Translation = new List<string>();           //翻译

    public List<string> Deformation = new List<string>();           //单词变形

    public Text InputText;

    //点击单词
    public void Button()
    {
        InputText.gameObject.GetComponentInParent<InputField>().text = Name;
    }
}

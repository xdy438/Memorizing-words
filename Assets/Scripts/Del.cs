using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;

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
        Id = 0;
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
                        if (Dictionaries.WordDic[i].Name==InputText.text)
                        {
                            Id = Dictionaries.WordDic[i].Id;
                            Name = Dictionaries.WordDic[i].Name;
                            Translation = Dictionaries.WordDic[i].Translation;
                            Deformation = Dictionaries.WordDic[i].Deformation;

                        }
                        GameObject obj = Instantiate(PreText);
                        obj.transform.SetParent(_content.transform);
                        obj.GetComponent<Text>().text = Dictionaries.WordDic[i].Name;
                        obj.GetComponent<WordInformation>().Id = Dictionaries.WordDic[i].Id;
                        obj.GetComponent<WordInformation>().Name = Dictionaries.WordDic[i].Name;
                        obj.GetComponent<WordInformation>().Deformation = Dictionaries.WordDic[i].Deformation;
                        obj.GetComponent<WordInformation>().Translation = Dictionaries.WordDic[i].Translation;
                        obj.GetComponent<WordInformation>().InputText = InputText;
                        obj.name = Dictionaries.WordDic[i].Name;
                    }
                }

                //如果没有则隐藏下拉框
                if (_content.transform.childCount==0)
                {
                    Frames.SetActive(false);
                }

                //如果搜出想要的则隐藏下拉框
                StartCoroutine(B());
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

    //如果搜出想要的则隐藏下拉框,延迟进行，防止系统没法反应过来
    public IEnumerator B()
    {
        yield return new WaitForSeconds(0.04f);
        if (InputText.text == Name)
        {
            //TODO 显示单词信息
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
        yield break;
    }

    //删除按钮
    public void DelButton()
    {
        if (Id!=0)
        {
            //字典中移除
            if (Id == Dictionaries.WordDic.Count)
            {
                Dictionaries.WordDic.Remove(Id);
            }
            else
            {
                for (int i = Id; i < Dictionaries.WordDic.Count; i++)
                {
                    Dictionaries.WordDic[i].Name = Dictionaries.WordDic[i + 1].Name;
                    Dictionaries.WordDic[i].Deformation = Dictionaries.WordDic[i + 1].Deformation;
                    Dictionaries.WordDic[i].Translation = Dictionaries.WordDic[i + 1].Translation;
                }
                Dictionaries.WordDic.Remove(Dictionaries.WordDic.Count);
            }

            //XML中移除
            TextAsset textAsset = (TextAsset)Resources.Load("单词");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(textAsset.text);                         //XML文件路径加载

            //找到根节点rood
            XmlNode rootnode = xmldoc.SelectSingleNode("root");
            XmlNodeList nodes = xmldoc.GetElementsByTagName("item");
            //删除节点
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                XmlNode node = nodes[i];
                if (node.Attributes["Id"] != null
                    && node.Attributes["Id"].Value == ""+Id)
                {
                    node.ParentNode.RemoveChild(node);
                }
            }

            //后节点前移
            for (int i = Id-1; i < rootnode.ChildNodes.Count; i++)
            {
                var xmlAttributeCollection = rootnode.ChildNodes[i].Attributes;
                if (xmlAttributeCollection != null)
                {
                    xmlAttributeCollection["Id"].InnerText = "" + (i+1);
                    Debug.Log(xmlAttributeCollection["Id"].InnerText);
                }

            }
            xmldoc.Save(Application.dataPath + "/Resources/单词.XML");
            Id = 0;
            InputText.gameObject.GetComponentInParent<InputField>().text = null;
            Introduce.text = null;
            Debug.Log("删除成功");
        }
    }
}

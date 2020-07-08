using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

//词典
public class Dictionaries : MonoBehaviour
{
    public static Dictionary<int, Word> WordDic
        = new Dictionary<int, Word>();                          //申请字典


   void Awake()
    {
        Read();
    }


   void Read()
   {
       TextAsset textAsset = (TextAsset) Resources.Load("单词");
       XmlDocument xmldoc = new XmlDocument();
       xmldoc.LoadXml(textAsset.text);                         //XML文件路径加载

        //找到根节点rood
        XmlNode rootnode = xmldoc.SelectSingleNode("root");

       for (int i = 0; i < rootnode.ChildNodes.Count; i++)
       {
           Word infoDic = new Word();
           var xmlAttributeCollection = rootnode.ChildNodes[i].Attributes;
           int id = 0;
           if (xmlAttributeCollection != null)
           {
               id = Int32.Parse(xmlAttributeCollection["Id"].InnerText);
               infoDic.Id = id;
           }

           string name = rootnode.ChildNodes[i].ChildNodes[0].InnerText;
           infoDic.Name = name;

           string translationType = rootnode.ChildNodes[i].ChildNodes[1].InnerText;
           string[] translation = translationType.Split(',');
           List<string> traList = new List<string>();
           foreach (var s in translation)
           {
               traList.Add(s);
           }

           infoDic.Translation = traList;

           string deformationType = rootnode.ChildNodes[i].ChildNodes[2].InnerText;
           string[] deformation = deformationType.Split(',');
           List<string> defList = new List<string>();
           foreach (var s in deformation)
           {
               defList.Add(s);
           }

           infoDic.Deformation = defList;

           if (id != 0)
           {
               WordDic.Add(id, infoDic);
           }
       }

    }
}
public class Word
{
    public int Id;

    public string Name;

    public List<string> Translation = new List<string>();           //翻译

    public List<string> Deformation = new List<string>();           //单词变形
}
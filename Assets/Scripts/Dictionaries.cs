﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

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
       TextAsset textAsset = (TextAsset)Resources.Load("单词");
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

           string type = null;                                  //申请string用来接收
           type = rootnode.ChildNodes[i].ChildNodes[1].InnerText;
            string[] Strings = type.Split(',');
           List<string> StrList=new List<string>();
           foreach (var s in Strings)
           {
               StrList.Add(s);
           }

           infoDic.Translation = StrList;

           type = rootnode.ChildNodes[i].ChildNodes[2].InnerText;
           Strings = type.Split(',');
           StrList.Clear();
           foreach (var s in Strings)
           {
               StrList.Add(s);
           }

           infoDic.Deformation = StrList;

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

    public List<string> Translation;                                //翻译

    public List<string> Deformation;                                //单词变形
}
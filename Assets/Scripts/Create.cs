using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.UI;

//增加
public class Create : MonoBehaviour
{
    public Text Word;                                   //单词文本框
    public Text[] Translation;                          //翻译
    public Text[] Deformation;                          //变形

    //增加按钮
    public void ButtonCreate()
    {
        if (Word.text!=null)
        {
            if (Tf())
            {
                Word infoDic = new Word();
                TextAsset textAsset = (TextAsset)Resources.Load("单词");
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(textAsset.text);                         //XML文件路径加载

                //找到根节点rood
                XmlNode rootnode = xmldoc.SelectSingleNode("root");
                XmlElement info = xmldoc.CreateElement("item");     //创建新的子节点
                info.SetAttribute("Id", "" + (Dictionaries.WordDic.Count + 1));


                int id = Dictionaries.WordDic.Count + 1;
                infoDic.Id = id;

                XmlElement name = xmldoc.CreateElement("名字");     //创建新子节点的子节点
                name.InnerText = Word.text;
                infoDic.Name = Word.text;

                string str = null;
                List<string> traList = new List<string>();
                for (int i = 0; i < Translation.Length; i++)
                {
                    if (Translation[i].text.Length!=0)
                    {
                        switch (i)
                        {
                            case 0:
                                str = "v." + Translation[i].text;
                                traList.Add("v." + Translation[i].text);
                                break;
                            case 1:
                                str += "," + "n." + Translation[i].text;
                                traList.Add("n." + Translation[i].text);
                                break;
                            case 2:
                                str += "," + "adj." + Translation[i].text;
                                traList.Add("adj." + Translation[i].text);
                                break;
                            case 3:
                                str += "," + "adv." + Translation[i].text;
                                traList.Add("adv." + Translation[i].text);
                                break;
                            case 4:
                                str += "," + "vt." + Translation[i].text;
                                traList.Add("vt." + Translation[i].text);
                                break;
                            case 5:
                                str += "," + "vi." + Translation[i].text;
                                traList.Add("vi." + Translation[i].text);
                                break;
                        }
                    }
                }

                if (traList.Count != 0)
                {
                    infoDic.Translation = traList;
                }
                else
                {
                    infoDic.Translation.Add("未添加翻译");
                }

                XmlElement translation = xmldoc.CreateElement("翻译");

                translation.InnerText = str ?? "未添加翻译";

                string str1 = null;
                List<string> defList = new List<string>();
                for (int i = 0; i < Deformation.Length; i++)
                {
                    if (Deformation[i].text.Length!=0)
                    {
                        switch (i)
                        {
                            case 0:
                                str1 = "复数  " + Deformation[i].text;
                                defList.Add("复数  " + Deformation[i].text);
                                break;
                            case 1:
                                str1 = "," + "第三人称单数  " + Deformation[i].text;
                                defList.Add("第三人称单数  " + Deformation[i].text);
                                break;
                            case 2:
                                str1 = "," + "现在分词  " + Deformation[i].text;
                                defList.Add("现在分词  " + Deformation[i].text);
                                break;
                            case 3:
                                str1 = "," + "过去式  " + Deformation[i].text;
                                defList.Add("过去式  " + Deformation[i].text);
                                break;
                            case 4:
                                str1 = "," + "过去分词  " + Deformation[i].text;
                                defList.Add("过去分词  " + Deformation[i].text);
                                break;
                            case 5:
                                str1 = "," + "形容词  " + Deformation[i].text;
                                defList.Add("形容词  " + Deformation[i].text);
                                break;
                            case 6:
                                str1 = "," + "比较级  " + Deformation[i].text;
                                defList.Add("比较级  " + Deformation[i].text);
                                break;
                            case 7:
                                str1 = "," + "最高级  " + Deformation[i].text;
                                defList.Add("最高级  " + Deformation[i].text);
                                break;
                        }
                    }
                }

                if (defList.Count!=0)
                {
                    infoDic.Deformation = defList;
                }
                else
                {
                    infoDic.Deformation.Add("单词没有变形");
                }
                XmlElement deformation = xmldoc.CreateElement("单词变形");

                deformation.InnerText = str1 ?? "单词没有变形";

                info.AppendChild(name);
                info.AppendChild(translation);
                info.AppendChild(deformation);

                rootnode.AppendChild(info);//将子节点按照创建顺序，添加到xml
                xmldoc.AppendChild(rootnode);
                xmldoc.Save(Application.dataPath + "/Resources/单词.XML");

                Dictionaries.WordDic.Add(id, infoDic);
                Debug.Log("成功");
            }
            else
            {
                Debug.Log("有了");
            }
        }
        
    }

    //判断是否已有单词
    private bool Tf()
    {
        for (int i = 1; i < Dictionaries.WordDic.Count + 1; i++)
        {
            if (Word.text== Dictionaries.WordDic[i].Name)
            {
                return false;
            }
        }

        return true;
    }
}

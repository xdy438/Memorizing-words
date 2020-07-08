using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//增删改脚本
public class CRUD : MonoBehaviour
{
    public GameObject CreateGameObject;                         //增加页面
    public GameObject DeleteGameObject;                         //删除页面
    public GameObject UpdateGameObject;                         //更新页面
    private GameObject _obj;                                    //接收当前页面                

    void Awake()
    {
        _obj = CreateGameObject;
    }

    //增加页面
    public void Create()
    {
        Show(CreateGameObject);
    }

    //删除页面
    public void Delete()
    {
        Show(DeleteGameObject);
    }

    //更新页面
    public void UpdateWord()
    {
        Show(UpdateGameObject);
    }

    //页面的显示与隐藏
    private void Show(GameObject obj)
    {
        if (_obj != obj)
        {
            _obj.SetActive(false);
            _obj = obj;
            _obj.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//返回主页面
public class Return : MonoBehaviour
{
    public void GetBack()
    {
        transform.parent.parent.gameObject.SetActive(false);
    }
}

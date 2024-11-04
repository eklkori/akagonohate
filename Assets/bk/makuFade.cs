using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makuFade : MonoBehaviour
{
    //いらないファイル？
    //MeshRenderer mr;
    void Start()
    {
        //mr = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        for (int i = 0; i < 255; i++)
        {
            //this.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 1);
            //Debug.Log(mr.material.color);
        }
    }
}

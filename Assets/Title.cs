using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkagonohateData akago = ScriptableObject.CreateInstance("AkagonohateData") as AkagonohateData;
        //akago = akagoDB.akagoList[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            /*if (akago.TutorealFlg==0) {
                TutorealFlg = 1;
                SceneManager.LoadScene("02Kiyaku");
            }
            else {
                SceneManager.LoadScene("05Home");
            } */
         }
    }
}

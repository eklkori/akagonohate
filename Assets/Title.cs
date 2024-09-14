using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private AkagoDB akagoDB;
    GameObject db;
    // Start is called before the first frame update
    void Start()
    {
        /*AkagonohateData akago = ScriptableObject.CreateInstance("AkagonohateData") as AkagonohateData;
        akago = akagoDB.akagoList[0];
        db = GameObject.Find("DBManager");*/
    }
    // Update is called once per frame
    void Update()
    {
        /*db.GetComponent<DBManager>().AddAkagoData();
        if (Input.GetMouseButtonUp(0)) {
            if (akago.TutorealFlg==0) {
                TutorealFlg = 1;
                SceneManager.LoadScene("02Kiyaku");
            }
            else {
                SceneManager.LoadScene("05Home");
            } 
         }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DBManager : MonoBehaviour
{
    [SerializeField] private AkagoDB akagoDB;
    // Start is called before the first frame update
    public void AddAkagoData(AkagonohateData akago)
    {
        akagoDB.akagoList.Add(akago);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AkagonohateData akago = ScriptableObject.CreateInstance("AkagonohateData") as AkagonohateData;
        akago = akagoDB.akagoList[0];
        if (Input.GetMouseButtonUp(0))
        {
            if (akago.tutorealFlg == 0)
            {
                akago.tutorealFlg = 1;
                SceneManager.LoadScene("02Kiyaku");
            }
            else
            {
                SceneManager.LoadScene("05Home");
            }
        }
    }
}

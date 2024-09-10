using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Naming : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void NamingOK()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("04Tutorial");
        }
    }
}

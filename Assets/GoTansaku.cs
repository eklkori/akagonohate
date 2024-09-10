using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTansaku : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void goTansaku()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("06Tansaku");
        }
    }
}

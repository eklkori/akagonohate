using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utage;
using UtageExtensions;

public class GoTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void goTutorial()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("04Tutorial");
            //JumpScenarioAsync("test", null);
        }
    }
}

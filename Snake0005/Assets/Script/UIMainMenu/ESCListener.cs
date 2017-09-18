using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCListener : MonoBehaviour
{

    
    public GameObject ButonPlay;
    public GameObject ButonRestart;
    public GameObject PanelESCMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

            PanelESCMenu.SetActive(true);
            ButonPlay.SetActive(false);
            ButonRestart.SetActive(false);
            ///
        }



    }
    public void quitMetod()
    {

        Debug.Log("Exit");
        Application.Quit();
    }
}

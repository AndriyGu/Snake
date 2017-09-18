using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCHelper : MonoBehaviour {

    public GameObject ExitPanelForMenu;
    public GameObject PanelWithButton;
    public GameObject ButonMenu;

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            
            ExitPanelForMenu.SetActive(true);
            PanelWithButton.SetActive(false);
            ButonMenu.SetActive(false);
    ///
}

        

    }
    public void quitMetod()
        {

        Debug.Log("Exit");
        Application.Quit();
    }
}

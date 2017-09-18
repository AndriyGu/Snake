using System;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Lewel1 : MonoBehaviour
{
    public Manager manager;
    public String nameButton;

    public void Start1Lewel()
    {
        //Debug.Log("Lewel 1");
       
        nameButton = transform.GetChild(0).GetComponent<Text>().text;

       // Debug.Log("fdgdf    "  + nameButton);

        Manager.Inst.name = nameButton;

        SceneManager.LoadScene(1);
        //progress.buttonNumber = nameButton;

      
        
       
    }
   
}
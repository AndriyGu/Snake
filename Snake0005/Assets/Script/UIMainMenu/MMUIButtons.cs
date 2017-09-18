using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMUIButtons : MonoBehaviour {
    public LevelManager levelManager;
    public Manager manager;


    public void LevelChossMenuLoad()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetProgress()
    {
        Manager.Inst.countUnlockedLevel = 1;
        
       
        //int name = Int32.Parse(Manager.Inst.name);
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Manager.Inst.mas[i, j] = 0;

            }
        }

        
    }
}

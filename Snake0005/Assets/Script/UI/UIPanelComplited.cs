using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPanelComplited : MonoBehaviour {
    public GameObject objectActivate;//--объект который нужно активировать
    private MainGameScript mainGame;
    


    public void levelComplited()
    {
        int name = Int32.Parse(Manager.Inst.name);
        Manager.Inst.mas[name, 0] = 1;  //меню вызывается когда уровень пройден, записует (1-true; 0-false)
        //если 1 то при выходе очки сохранятся.

    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0F;
       // mainGame.buttonResumeCliced = false;
       // mainGame.PanelLevelComplited.SetActive(false);
    }

}

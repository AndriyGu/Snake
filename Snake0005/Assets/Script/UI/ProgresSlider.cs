using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgresSlider : MonoBehaviour {
    private MainGameScript mainGame;
    private Slider slider;
    private UIPanelComplited panelComplited;
    private Lewel1 level;

    void Awake()
    {
              mainGame = GameObject.FindGameObjectWithTag("MainCameraTAG").GetComponent<MainGameScript>();

      //panelComplited = GameObject.FindGameObjectWithTag("PanelLevelTag").GetComponentsInChildren<>; 
      //Debug.Log(panelComplited);
      //Debug.Log("Progress Score  Awake = ");
      //  Debug.Log("ProgresSlider maingame         "+mainGame);
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
      //  Debug.Log("Progress Score  = " + mainGame.score);
        //Debug.Log("scoreGrade = " + mainGame.scoreGrade);
       // Debug.Log("score = " + mainGame.score);
       // Debug.Log("slider = " + slider.value);

        slider.value = (100/mainGame.scoreGrade)*mainGame.score;
        
        //   panelComplited.gameObject.SetActive(slider.value >= 100);
        
    }
}

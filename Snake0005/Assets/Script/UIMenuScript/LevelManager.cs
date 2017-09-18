using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public int countUnlockedLevel = 0;// Manager.Inst.countUnlockedLevel;

    [SerializeField]
    Sprite unlockedIcon;

    [SerializeField]
    Sprite lockedIcon;

    // public GameObject panel;
    private Color basicColor = Color.red;
    private Color hoverColor = Color.green;
    // Use this for initialization
    void Start () {
        countUnlockedLevel = Manager.Inst.countUnlockedLevel;
   // Debug.Log("countUnlockedLevel   " + countUnlockedLevel);
        for (int i = 0; i < transform.childCount; i++)
        {
            int numLvl = i + 1;
            transform.GetChild(i).gameObject.name = numLvl.ToString();
            transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = numLvl.ToString();

           

         
           
          //  Debug.Log(Manager.Inst.mas[numLvl, 1]);
           
            if(Manager.Inst.mas[numLvl, 1] == 0)
            {
                transform.GetChild(i).transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "";
            }
            else
            {
                transform.GetChild(i).transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "" + Manager.Inst.mas[numLvl, 1];
                transform.GetChild(i).GetComponent<Image>().color = hoverColor;
            }

           

           

            transform.GetChild(i).GetComponent<Button>().interactable = i < countUnlockedLevel;

            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

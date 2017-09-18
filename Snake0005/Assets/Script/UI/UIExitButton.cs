using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIExitButton : MonoBehaviour {

    public void MainMenuLoader()
    {
        SceneManager.LoadScene(0);
    }

    //public void validRes()
    //{
    //    int name = Int32.Parse(Manager.Inst.name);

    //    if (Manager.Inst.mas[name, 0] == 1)
    //    {
    //        name = Int32.Parse(Manager.Inst.name);
    //        Manager.Inst.mas[name, 1] = Manager.Inst.s
    //    }
    //}

}

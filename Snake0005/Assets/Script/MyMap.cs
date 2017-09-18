using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMap : MonoBehaviour {

    public Sprite[] img;

//объявить номер выбранной картинки
    public int IndexImg = 0;

    //выбранная картинка в текущий момент

    int CurrentIndex = 0;



//Описать процесс смены картинки на блоке
    void Changeimg()

    {

        //если выбранная картинка отличается от той которая уже нарисована то меняем значение

        if (CurrentIndex != IndexImg)
        {

            //размер списка

            int Listsize = img.Length;

            //если номер не выходит за границы списка задаем номер картинки

            if (Listsize > IndexImg)
            {

                //получаем компонент который хранит картинку

                SpriteRenderer S = this.GetComponent<SpriteRenderer> ();// или
                //SpriteRenderer S = this.GetComponent<spriterenderer> ();</spriterenderer>

                //рисуем выбранную картинку

                S.sprite = img[IndexImg];

                //запоминаем текущий выбор картинки

                CurrentIndex = IndexImg;
            
}

        }

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Changeimg();
    }
}

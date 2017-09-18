using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager 
    {

        public static Manager Inst = new Manager();
        public int levelsQuantity = 20;
        //Данные
       
        public String name = "0";
        public int countUnlockedLevel = 1;
        public int scoreCurrent;
        //public int scoreComplited=0;    

        public int[,] mas = new int[25, 2];

        







}
//.......
//Обращаемся ИЗ ЛЮБОГО ОБЪЕКТА И ЛЮБОЙ СЦЕНЫ
//RoomManager.Inst.foo1=5f;


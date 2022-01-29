using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpenLevel : MonoBehaviour
{
     public Button[] levelBttns;// массив кнопок для уровней
     public static int lvlopen; // переменная для количества слов которые нужно открыть
       public static int LevelOpen; //пееременная для сравнение в файле GS2
       public Text ScoreAll;

    public void ExamLevel(int lvl)
    {
        if(lvl==1)//проверка выбора первого уровня
        {
          LevelOpen=lvl;
        }
        if(lvl==2) //проверка выбора второго уровня
        {
            LevelOpen=lvl;
        }
        if(lvl==3) //проверка выбора третьего уровня
        {
            LevelOpen=lvl;
        }
        if(lvl==4) //проверка выбора четвертого уровня
        {
            LevelOpen=lvl;
        }
        if(lvl==5) //проверка выбора пятого уровня
        {
            LevelOpen=lvl;
        }
        if(lvl==6) //проверка выбора шестого уровня
        {
            LevelOpen=lvl;
        }

    }

 public void Level1(){  

          int a=0;
        while(a<levelBttns.Length)//цикл для прохождения по массиву кнопок
            {
              if (a<=lvlopen) //открытие уровней условие
              {
                  levelBttns[a].interactable = true; //открываем уровень который меньше lvlopen
              }
              a++;  
            }
        
 }

 void Start()
    {
       for(int i =1; i< levelBttns.Length; i++) levelBttns[i].interactable = false; //отключаем все кнопки
       lvlopen=PlayerPrefs.GetInt("Qlvl");// приравнивается сохраненное значение с ключом "Qlvl"
       Statistics.StatisticsWord=PlayerPrefs.GetInt("QTwords"); // приравнивается сохраненное значение с ключом QTwords
       ScoreAll.text=" "+Statistics.StatisticsWord;
        Level1();//вызываем функцию в котором будем открывать уровни
        
    }
  
   void Update()
    {
        

        
    }
}

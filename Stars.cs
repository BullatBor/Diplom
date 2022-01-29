using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stars : MonoBehaviour
{
    public Sprite[] StarsIcon = new Sprite[2];
    public Image[] StarsExam1;
    public Image[] StarsLvl1;
    public Image[] StarsLvl2;
    public Image[] StarsLvl3;
    public Image[] StarsLvl4;
    public Image[] StarsLvl5;
    public Image[] StarsLvl6;
    public static int ExamTr=0;
    // Start is called before the first frame update
    public void ExamStar()
    {
        if(OpenLevel.lvlopen>=0)//присваивание звезд для 1 уровня
        {
        for(int i=0; i<Statistics.Examlvl1; i++)//цикл для массива StarsExam1
        {
          StarsExam1[i].sprite= StarsIcon[1]; //Элементу который прошел условие приравнивается спрайт со звездой
        }
        }
        if(OpenLevel.lvlopen>=1)//присваивание звезд для 2 уровня
        {
        for(int i=0; i<Statistics.Examlvl2; i++)//цикл для массива StarsExam1
        {
            StarsLvl2[i].sprite= StarsIcon[1];//Элементу который прошел условие приравнивается спрайт со звездой
        }
        }
        if(OpenLevel.lvlopen>=2)//присваивание звезд для 3 уровня
        {
        for(int i=0; i<Statistics.Examlvl3; i++)//цикл для массива StarsExam1
        {
            StarsLvl3[i].sprite= StarsIcon[1];//Элементу который прошел условие приравнивается спрайт со звездой
        }
        }
        if(OpenLevel.lvlopen>=3)//присваивание звезд для 4 уровня
        {
        for(int i=0; i<Statistics.Examlvl4; i++)//цикл для массива StarsExam1
        {
            StarsLvl4[i].sprite= StarsIcon[1];//Элементу который прошел условие приравнивается спрайт со звездой
        }
        }
        if(OpenLevel.lvlopen>=5)//присваивание звезд для 5 уровня
        {
        for(int i=0; i<Statistics.Examlvl5; i++)//цикл для массива StarsExam1
        {
            StarsLvl5[i].sprite= StarsIcon[1];//Элементу который прошел условие приравнивается спрайт со звездой
        }
        }
        if(OpenLevel.lvlopen>=6)//присваивание звезд для 6 уровня
        {
        for(int i=0; i<Statistics.Examlvl6; i++)//цикл для массива StarsExam1
        {
            StarsLvl6[i].sprite= StarsIcon[1];//Элементу который прошел условие приравнивается спрайт со звездой
        }
        }
    }
    
    void Start()
    { 
        OpenLevel.lvlopen=PlayerPrefs.GetInt("Qlvl");//заполнение переменной lvlopen сохраненным значением с ключом "Qlvl"
         Statistics.Examlvl1=PlayerPrefs.GetInt("QStar"); //заполнение переменной Examlvl1 сохраненным значением с ключом "QStar"
        Statistics.Examlvl2=PlayerPrefs.GetInt("Qlvl2");  //заполнение переменной Examlvl2 сохраненным значением с ключом "Qlvl2"
        Statistics.Examlvl3=PlayerPrefs.GetInt("Qlvl3");//заполнение переменной Examlvl3 сохраненным значением с ключом "Qlvl3"
        Statistics.Examlvl4=PlayerPrefs.GetInt("Qlvl4");//заполнение переменной Examlvl4 сохраненным значением с ключом "Qlvl4"
        Statistics.Examlvl5=PlayerPrefs.GetInt("Qlvl5");//заполнение переменной Examlvl5 сохраненным значением с ключом "Qlvl5"
        Statistics.Examlvl6=PlayerPrefs.GetInt("Qlvl6");//заполнение переменной Examlvl6 сохраненным значением с ключом "Qlvl6"
        ExamStar(); //вызов функции
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public static int StatisticsWord; //статистика выученных слов
    public static int StaticExam; //количество слов в экзамене
    public static int ScoreExam1; //количество правильных ответов в экзамене
    public static int ScoreExam2;
    public static int ScoreExam3;
    public static int ScoreExam4;
    public static int ScoreExam5;
    public static int ScoreExam6;
    public static int Scorelvl;
    public static int Exam1; //переменная для звезд
    public static int Examlvl1;
    public static int Examlvl2;
    public static int Examlvl3;
    public static int Examlvl4;
    public static int Examlvl5;
    public static int Examlvl6;
    public Text ScoreExam;


    public void checkExam1() //присваивание звезд
    {
       if(Scorelvl>((StaticExam*50)/100))// если правильных ответов больше 50% от количества слов
       {
           Exam1=1;
       }
        if(Scorelvl>((StaticExam*75)/100))// если правильных ответов больше 50% от количества слов
       {
           Exam1=2;
       }
        if(Scorelvl>((StaticExam*90)/100))// если правильных ответов больше 50% от количества слов
       {
           Exam1=3;
       }      

        switch(OpenLevel.lvlopen)  
        {
          case 1: //если количество открытых уровней равно 1 то
           Examlvl1=Exam1;//переменная для количества звезд в первом уровне
           PlayerPrefs.SetInt("QStar",Examlvl1); //сохранение значения переменной с ключом QStar
           StaticExam=0; // обнуляем количество слов в экзамене
          break;
          case 2://если количество открытых уровней равно 2 то
           Examlvl2=Exam1;//переменная для количества звезд во втором уровне
           PlayerPrefs.SetInt("Qlvl2", Examlvl2); //сохранение значения переменной с ключом Qlvl2
           StaticExam=0; // обнуляем количество слов в экзамене
          break;
          case 3: //если количество открытых уровней равно 3 то
           Examlvl3=Exam1;//переменная для количества звезд в третьем уровне
           PlayerPrefs.SetInt("Qlvl3", Examlvl3); //сохранение значения переменной с ключом Qlvl3
          StaticExam=0; // обнуляем количество слов в экзамене
          break;
          case 4://если количество открытых уровней равно 4 то
           Examlvl4=Exam1;//переменная для количества звезд во 4 уровне
           PlayerPrefs.SetInt("Qlvl4", Examlvl4); //сохранение значения переменной с ключом Qlvl3
          StaticExam=0; // обнуляем количество слов в экзамене
          break;
          case 5://если количество открытых уровней равно 5 то
           Examlvl5=Exam1;
           PlayerPrefs.SetInt("Qlvl5", Examlvl5); 
          StaticExam=0;
          break;
          case 6://если количество открытых уровней равно 6 то
           Examlvl6=Exam1;
           PlayerPrefs.SetInt("Qlvl6", Examlvl6); 
          StaticExam=0;
          break;
              
        }
    }
    public void Admin()
        {
            GS2.end=1;

        }
       public void Admin1()
        {
            Examlvl1=0;
            Examlvl2=0;
            OpenLevel.lvlopen=3;
              StatisticsWord=0;
            PlayerPrefs.SetInt("QStar",Examlvl1);
        PlayerPrefs.SetInt("Qlvl2", Examlvl2); 
            PlayerPrefs.SetInt("Qlvl",OpenLevel.lvlopen);
             PlayerPrefs.SetInt("QTwords",StatisticsWord);
        }
    // Start is called before the first frame update
    void Start()
    { 
        StatisticsWord=PlayerPrefs.GetInt("QTwords");
        OpenLevel.lvlopen=PlayerPrefs.GetInt("Qlvl");      
    }
     private void OnApplicationQuit()
     {
         PlayerPrefs.Save();
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}

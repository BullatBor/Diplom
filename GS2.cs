
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GS2 : MonoBehaviour
{
   
      public QuestionList[] questions; //cписок с вопросами и ответами
      public Text[] answersText; //массив текста для кнопок
      public string[] answersmass; //массив для переводом
      public Text qText; //текст для выовда вопроса
      public Button[] answerBttns= new Button[3];//массив кнопок
      public Image[] BttnColors = new Image[3]; // массив изображении для изменения цвета

      public Color gr; //зеленый цвет для правильного ответа
      public Color fl;  //красный цвет для неправильного ответа
      public Color Blue; // синий цвет кнопок

      public Text Score; //очки
      public Text ScoreEx; //текст для вывода количества очков
        public GameObject Menu; //выпадающее меню
        public GameObject StartPanel; //панель в начале игры
       public string [] Qindex; //массив для ошибок
      List<object> qList; //пустой список
      QuestionList crntQ; //
      int randQ; //переменная для 
      int sc=0;//очки
      int W=0; //идекс для движения по массиву с ошибками
      int OneAnswer;//условие проверки 
      public TextAsset All; // сюда перекидывать текстовый файл
      string Text;
      int f = 0;
      int i = 0;
      int Q;
      string indexQ;
      public static int end=0;
      public static int exam;
      int j=0;
      public static int Qwords=0;
    //моё
    public GameObject Lesson;
    private bool Less = true;

    public void OnClickPlay1()
      {
          qList = new List<object>(questions);
          Q=1;
          start();
          OneAnswer=1;
           for(int i=0; i<Qindex.Length;i++)
         {
           Qindex[i]="null";
         }
         questionGenerate();
        
       
      }
      public void ExamBttn()
      {
        qList = new List<object>(questions);
          OneAnswer=1;
          Q=3;
          exam=1;
             for(int i=0; i<Qindex.Length;i++)
         {
           Qindex[i]="null";
         }
          start();
         questionGenerate();
        
      }
     public void start(){
       StartPanel.GetComponent<Animator>().enabled= true;
            StartPanel.GetComponent<Animator>().SetTrigger("In");
     }

    public void Lesson1()
    {
        Less = !Less;
        Lesson.SetActive(Less);

    }


    //анимация одной кнопки 
    IEnumerator animBttns1()
      {
        
            
            answerBttns[0].interactable = false;
              if (!answerBttns[0].gameObject.activeSelf) answerBttns[0].gameObject.SetActive(true);
              else answerBttns[0].gameObject.GetComponent<Animator>().SetTrigger("In");
               yield return new WaitForSeconds(0.5f);
             
            
              answerBttns[0].interactable = true;
              yield break;
             
            
            
      }
    

     public void questionGenerate()
       { 
         for(int b=0;b<BttnColors.Length;b++)
         {
           BttnColors[b].color=Blue;
         }
         
         //выбор с одним вопросом
if(Q==1)
{
         OneAnswer=1;
       
        if(qList.Count> 0)
        {
        randQ = Random.Range(0,qList.Count);
        crntQ = qList[randQ] as QuestionList;
        qText.text=crntQ.question;
      List<string> answers = new List<string>(crntQ.answers);
 answersText[0].text=answers[0];
 answers.RemoveAt(0);
          
          StartCoroutine(animBttns1());
        }
        else
        {
          
          print("Элс");
          OneAnswer=1;
           qList = new List<object>(questions);
          questionGenerate();
          
            Q=2;
        }
}
       
         //выбор двух вариантов ответов        
         if(Q==2)
        {//заранее создан новый список qList в котором содержаться слова и варианты ответов к нему
        if(qList.Count>0)//проверка количества элементов в списке должно быть больше 0
        {
          randQ = Random.Range(0,qList.Count);  //генерируется случайное число от 0 до количества элементов в списке 
        crntQ = qList[randQ] as QuestionList;  // выбор случайного элемент списка 
        qText.text=crntQ.question;      //вывод на экран вопроса
           indexQ=crntQ.question;       //в переменную indexQ заносится вопрос
        List<string> answers = new List<string>(crntQ.answers); //новый список в котором будут находится варианты ответов
      for(int i=0; i < crntQ.answers.Length; i++)//цикл для массива
      {
 int rand= Random.Range(0,answers.Count-1);// генерация числа от 0 до предпоследнего элемента массива
 answersText[i].text=answers[rand]; // заносим в текстовый обьект вариант ответа
 answers.RemoveAt(rand);//удаляем вариант ответа из списка с индексом rand
          }
          StartCoroutine(animBttns()); // вызов функции animBttns() для анимации кнопок
            
        }
        else
        {
          Q=3;//условие для вывода 3х вариантов ответов
          qList = new List<object>(questions);// заполняем qList 
          questionGenerate();           // вызываем функцию question generate
        }
        }

        // Выбор 3 вариантов ответов
        if(Q==3)
        
        {
        if(qList.Count> 0)
        {
        randQ = Random.Range(0,qList.Count);
        crntQ = qList[randQ] as QuestionList;
      qText.text=crntQ.question;
  
      List<string> answers = new List<string>(crntQ.answers);
      for(int i=0; i < crntQ.answers.Length; i++)
      {
 int rand= Random.Range(0,answers.Count);
 answersText[i].text=answers[rand];
 answers.RemoveAt(rand);
          }
          StartCoroutine(animBttns());
          
        }
        else
        {
          if(exam!=1)
          {
          qList = new List<object>(questions);
          Q=4;
          questionGenerate();
          }
          else
          {
            end=1;
             StartCoroutine(trueOrFalse(false));
          }
        }
        }
//Неправильные ответы

            if(Q==4)
        {
          OneAnswer=2;
        if(f<Qindex.Length)
        {
          if(Qindex[f]!="null")
          {
            
          for(int g=0; g<qList.Count;g++)
          {
            crntQ = qList[g] as QuestionList;
                if(Qindex[f]==crntQ.question)
                {
                   qText.text=crntQ.question;
                   List<string> answers = new List<string>(crntQ.answers);
                   for(int i=0; i < crntQ.answers.Length; i++)
                     {
                         int rand= Random.Range(0,answers.Count);
                         answersText[i].text=answers[rand];
                         answers.RemoveAt(rand);
                     }
                  StartCoroutine(animBttns());
                  
                  break;
                }
          }
          }
          else{
            end=1;
          }
         
        }
                else
        {
          end=1;
        }
          }
        }
           
           //Анимация кнопок
      IEnumerator animBttns()
      {
        //анимация 2х кнопок
        if(Q==2) // количество кнопок которые будут анимированы
        {
            for(int i =0; i< answerBttns.Length-1; i++) answerBttns[i].interactable = false;//отключение кнопок.
            int a=0;
            while(a<answerBttns.Length-1)// цикл по массиву кнопок кроме последнего элемента
            {
              if (!answerBttns[a].gameObject.activeSelf) answerBttns[a].gameObject.SetActive(true);//проверка кнопки 
              else answerBttns[a].gameObject.GetComponent<Animator>().SetTrigger("In"); //вызов анимации по триггеру
              a++;// переход по массиву
               yield return new WaitForSeconds(0.5f);      //пауза       
            }
                for(int i =0; i< answerBttns.Length-1; i++) answerBttns[i].interactable = true;//включение кнопок
              yield break;
        }
        //анимация 3х кнопок
              if(Q==3)
        {
           // yield return new WaitForSeconds(1);
            for(int i =0; i< answerBttns.Length; i++) answerBttns[i].interactable = false;
            int a=0;
            while(a<answerBttns.Length)
            {
              if (!answerBttns[a].gameObject.activeSelf) answerBttns[a].gameObject.SetActive(true);
              else answerBttns[a].gameObject.GetComponent<Animator>().SetTrigger("In");
              a++;
               yield return new WaitForSeconds(0.5f);
            }
                for(int i =0; i< answerBttns.Length; i++) answerBttns[i].interactable = true;
              yield break;
        }
        //анимация кнопок для неправильных ответов
        if(Q==4)
        {
            yield return new WaitForSeconds(1);
            for(int i =0; i< answerBttns.Length; i++) answerBttns[i].interactable = false;
            int a=0;
            while(a<answerBttns.Length)
            {
              if (!answerBttns[a].gameObject.activeSelf) answerBttns[a].gameObject.SetActive(true);
              else answerBttns[a].gameObject.GetComponent<Animator>().SetTrigger("In");
              a++;
               yield return new WaitForSeconds(1);
             
            }
                for(int i =0; i< answerBttns.Length; i++) answerBttns[i].interactable = true;
              yield break;
        }      
      }
      //Проверка ответа на правильность
      IEnumerator trueOrFalse(bool check)//действия после проверки
      {
           for(int i =0; i< answerBttns.Length; i++) answerBttns[i].interactable = false;//отключаем кнопки, делаем не кликабельными
      yield return new WaitForSeconds(0.5f);//пауза в 0,5с
       for(int i =0; i< answerBttns.Length; i++) answerBttns[i].gameObject.GetComponent<Animator>().SetTrigger("Out");// вызов анимации исчезновения кнопок
       if(check)//проверка на true и false
      {
        if(OneAnswer==1)//проверка на то что вопросы из массива с впоросами
        {
       yield return new WaitForSeconds(1);
        qList.RemoveAt(randQ);
       questionGenerate();
       sc++;
        }
         if(OneAnswer==2)//проверка на то что вопросы из ошибочных вариантов
        {    
       yield return new WaitForSeconds(1);
       questionGenerate();
       f++;
       sc++;
        }        
      if(end==1)
      {
          if(!Menu.GetComponent<Animator>().enabled) Menu.GetComponent<Animator>().enabled= true; // анимация панели
         else Menu.GetComponent<Animator>().SetTrigger("In"); 

         if(exam==1)// условие на то что пользователь прошел экзамен
         {
             lvlcheck(); //вызываем функцию для открытия нового уровня
             GameObject.Find("ExamStar").GetComponent<Statistics>().checkExam1();// вызов функции checkExam1 из другого файла
             exam=0;// отключаем условие до след экзамена
         }
         
      }
       if(exam==1)
       {
       ScoreEx.text=" "+sc;
       }
       end=0;
      } 
      else
      { 
        if(OneAnswer==1)
        {
          if(exam==1)
          {
              yield return new WaitForSeconds(1);
        qList.RemoveAt(randQ);
       questionGenerate();
          }
          else{
         Qindex[W]= crntQ.question;
             W++;
      yield return new WaitForSeconds(1);
        qList.RemoveAt(randQ);
       questionGenerate();
          }
        }
      if(OneAnswer==2)
        {
          for(int h=0; h<Qindex.Length;h++)
          {
            if(Qindex[h]=="null")
            {
              Qindex[h]=crntQ.question;
            }
          }
          Debug.Log("Error");
         f++;
       yield return new WaitForSeconds(1);
       questionGenerate();
        }
        if(end==1)
      {
          if(!Menu.GetComponent<Animator>().enabled) Menu.GetComponent<Animator>().enabled= true; // анимация панели
         else Menu.GetComponent<Animator>().SetTrigger("In"); 
         if(exam==1)// условие на то что пользователь прошел экзамен
         {
             lvlcheck(); //вызываем функцию для открытия нового уровня
             GameObject.Find("ExamStar").GetComponent<Statistics>().checkExam1();// вызов функции checkExam1 из другого файла
             exam=0;// отключаем условие до след экзамена
         }
         
      }
      }
      }

      public void answersBttns(int index)//новая функция и присваивание кнопке индекса
      {
        if(answersText[index].text.ToString()== crntQ.answers[0])//проверка варианта ответа с первым элементом массива ответов
        { StartCoroutine(trueOrFalse(true));//если условие проходит то вызываем функцию trueOrFalse со значением true
       BttnColors[index].color=gr;//меняем цвет кнопки на зеленый

        }
        else
        { StartCoroutine(trueOrFalse(false));//если условие не проходит то вызываем функцию trueOrFalse со значением true
            BttnColors[index].color=fl;//меняем цвет кнопки на красный
            
        }
      }
      //открытие новых уровней
      public void lvlcheck()
      {
        switch(OpenLevel.LevelOpen)
        {
          case 1:
          if(sc> Statistics.ScoreExam1)//проверка колиечства очков с предыдущим колчиеством очков в этом уровне
          {  
            Statistics.Scorelvl=sc;
          Statistics.ScoreExam1=sc; //приравниваем количество очков в переменную ScoreExam1 для присваивания звезд
        Statistics.StatisticsWord=Statistics.StatisticsWord+Statistics.ScoreExam1; //увеличение количества выученных слов
         PlayerPrefs.SetInt("QTwords",Statistics.StatisticsWord);//сохранение количества выученных слов
          }
          if(OpenLevel.lvlopen>=1) break;
           OpenLevel.lvlopen=1;  
           PlayerPrefs.SetInt("Qlvl",OpenLevel.lvlopen);     
           Statistics.Scorelvl=sc;
          break;

          case 2:
          if(sc> Statistics.ScoreExam2)
          {

           Statistics.ScoreExam2=sc; //приравниваем количество очков в переменную ScoreExam1 для присваивания звезд
        Statistics.StatisticsWord=Statistics.StatisticsWord+Statistics.ScoreExam2; //увеличение количества выученных слов
         PlayerPrefs.SetInt("QTwords",Statistics.StatisticsWord);//сохранение количества выученных слов
          }
          if(OpenLevel.lvlopen>=2) break;
           OpenLevel.lvlopen=2;
           PlayerPrefs.SetInt("Qlvl",OpenLevel.lvlopen); 
           Statistics.Scorelvl=sc;
          break;
          case 3:
             if(sc> Statistics.ScoreExam3)
          {
             Statistics.Scorelvl=sc;
           Statistics.ScoreExam5=sc; //приравниваем количество очков в переменную ScoreExam1 для присваивания звезд

        Statistics.StatisticsWord=Statistics.StatisticsWord+Statistics.ScoreExam3; //увеличение количества выученных слов
         PlayerPrefs.SetInt("QTwords",Statistics.StatisticsWord);//сохранение количества выученных слов
          }
          if(OpenLevel.lvlopen>=3) break;
           OpenLevel.lvlopen=3;
           PlayerPrefs.SetInt("Qlvl",OpenLevel.lvlopen); 
           Statistics.Scorelvl=sc;
          break;
          case 4:
           if(sc> Statistics.ScoreExam4)
          {
             Statistics.Scorelvl=sc;
           Statistics.ScoreExam4=sc; //приравниваем количество очков в переменную ScoreExam1 для присваивания звезд
        Statistics.StatisticsWord=Statistics.StatisticsWord+Statistics.ScoreExam4; //увеличение количества выученных слов
         PlayerPrefs.SetInt("QTwords",Statistics.StatisticsWord);//сохранение количества выученных слов
          }
          if(OpenLevel.lvlopen>=4) break;
           OpenLevel.lvlopen=4;
           PlayerPrefs.SetInt("Qlvl",OpenLevel.lvlopen);
           Statistics.Scorelvl=sc;
          break;
          case 5:
           if(sc> Statistics.ScoreExam5)
          {
             Statistics.Scorelvl=sc;
           Statistics.ScoreExam5=sc; //приравниваем количество очков в переменную ScoreExam1 для присваивания звезд
        Statistics.StatisticsWord=Statistics.StatisticsWord+Statistics.ScoreExam5; //увеличение количества выученных слов
         PlayerPrefs.SetInt("QTwords",Statistics.StatisticsWord);//сохранение количества выученных слов
          }
          if(OpenLevel.lvlopen>=5) break;
           OpenLevel.lvlopen=5;
           PlayerPrefs.SetInt("Qlvl",OpenLevel.lvlopen);
          break;
          case 6:
          if(sc> Statistics.ScoreExam5)
          {
             Statistics.Scorelvl=sc;
           Statistics.ScoreExam6=sc; //приравниваем количество очков в переменную ScoreExam1 для присваивания звезд
        Statistics.StatisticsWord=Statistics.StatisticsWord+Statistics.ScoreExam6; //увеличение количества выученных слов
         PlayerPrefs.SetInt("QTwords",Statistics.StatisticsWord);//сохранение количества выученных слов
          }
           Statistics.Scorelvl=sc;
          Statistics.ScoreExam6=sc; //приравниваем количество очков в переменную ScoreExam1 для присваивания звезд
        Statistics.StatisticsWord=Statistics.StatisticsWord+ Statistics.ScoreExam6; //увеличение количества выученных слов
         PlayerPrefs.SetInt("QTwords",Statistics.StatisticsWord);//сохранение количества выученных слов
          break;
              
        }
      }

        // Выборка слов 
      void Start()
    {
      for(int l=0;l<answersmass.Length; l++)
      {
        answersmass[l]="null";
      }
      
        Text = All.text;
           string[] s = Text.Split('/');
            for(int x=0; x<s.Length; x++)
           {
             string[] A = s[x].Split('.');
             questions[x].question=A[0];
             questions[x].answers[0]=A[1];
             answersmass[x]=A[1];
           }
            for(int x=0; x<s.Length;x++)
            {
               Qwords++;
            }
            Statistics.StaticExam=Qwords;
            j=0;
           while(j<s.Length)
           {
             
             int n=0;
             int n1=2;
             int NQ=1;
           while(NQ<4)
             {
               if(n==0)
               {
                 int randM=Random.Range(0,Qwords);
                if(answersmass[randM]!=questions[j].answers[0] )
                {                 
                       questions[j].answers[NQ]=answersmass[randM];
                       NQ=2;
                       n=1;
                       n1=0;
                }
               }
               if(n1==0)
               {
               int randM=Random.Range(0,Qwords);
                if(answersmass[randM]!=questions[j].answers[0] && answersmass[randM]!=questions[j].answers[1] )
                {
                       questions[j].answers[NQ]=answersmass[randM];
                       j++;
                       n1=2;
                       NQ=1;
                       n=0;
                       break;
                       
                }
               }
             }
           }
           Qwords=0;//обнуляем количество слов
    }
    void Update()
    {
         if (Input.GetKeyDown (KeyCode.X))
        {
            end=1;
        }
    }
}
  
    [System.Serializable]
        public class QuestionList
    {
       public string question;
       public string[] answers= new string[3];
    }


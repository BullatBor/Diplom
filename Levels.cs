using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{

    //тема Семья уровень1

    
    public void NextLevel(int index)  
    {             
        SceneManager.LoadScene(index); 
    }


    void Start()
    {
       
    }
    void Update(){
     
    }
}

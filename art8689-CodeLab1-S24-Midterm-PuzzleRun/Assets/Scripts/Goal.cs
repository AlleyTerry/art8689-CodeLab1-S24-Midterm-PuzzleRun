using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Goal : MonoBehaviour
{
    
    int levelNum = 0;
    public static Goal instance;
    
    void OnTriggerEnter(Collider other)
    {
        if (LoadGame.instance.camera2.activeInHierarchy == true)
        {
            
            levelNum++;
            SceneManager.LoadScene(levelNum);
            LoadGame.instance.camera2.SetActive(false);
            LoadGame.instance.camera1.SetActive(true);
            LoadGame.instance.goalbutton.SetActive(true);
            
        }
        
        
    }
    
  
    
    public void ResetStage()
    {
        LoadGame.instance.camera1.SetActive(true);
        LoadGame.instance.camera2.SetActive(false);
        ASCIILevelLoader.instance.CurrentLevel++;
        ASCIILevelLoader.instance.CurrentLevel--;
        CameraFollow.instance.targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    
 
    
    
    
}

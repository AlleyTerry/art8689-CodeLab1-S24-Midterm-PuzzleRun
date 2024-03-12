using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    public GameObject goalbutton;
    private MoveableObjects loaderScript;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject managerObject;

    public static LoadGame instance;
    //public int asciiLevelNum = Goal.instance.levelNum;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //loaderScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<MoveableObjects>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonLoader()
    {
        //camera1.SetActive(false);
        //camera2.SetActive(true);
        //loaderScript.LoaderLevel();
        Camera.main.transform.parent = managerObject.transform;
        
    }

    public void ResetLevel()
    {
        
        
        LoadGame.instance.camera2.SetActive(false);
        LoadGame.instance.camera1.SetActive(true);
        LoadGame.instance.camera1.transform.parent = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //CameraFollow.instance.targetPlayer = 
        //SceneManager.LoadScene(Goal.instance.levelNum);
        
      
        
    }
   

    public void NextLevelLoad()
    {

        ASCIILevelLoader.instance.CurrentLevel++;
        CameraFollow.instance.targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
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
        //Camera.main.transform.parent = LoadGame.instance.managerObject.transform;
        CameraFollow.instance.targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        LoadGame.instance.camera2.SetActive(false);
        LoadGame.instance.camera1.SetActive(true);
        //SceneManager.LoadScene(Goal.instance.levelNum);
        
      
        
    }
   

    public void NextLevelLoad()
    {

        ASCIILevelLoader.instance.CurrentLevel++;
        CameraFollow.instance.targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
}

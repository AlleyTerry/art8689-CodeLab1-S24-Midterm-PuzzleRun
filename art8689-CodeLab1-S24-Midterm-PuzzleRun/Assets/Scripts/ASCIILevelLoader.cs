using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class ASCIILevelLoader : MonoBehaviour
{
    
    
    GameObject level;

    public int currentLevel = 0;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }

    //this is the file path to the txt file
    string FILE_PATH;
    
    public static ASCIILevelLoader instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //this finds the file path in game assuming the directory already exists
        //you can make a new file via the left side directory in Rider right click, add, file (add the type of file at the end"
        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";
        
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel()
    {
        Destroy(level);
        level = new GameObject("Level Objects");
        //set the read file into an array of strings and store it
        //now it laods the file path but replaces num with whatever the current level is 
        string[] lines = File.ReadAllLines(FILE_PATH.Replace("Num", currentLevel + ""));

        for (int yLevelPos = 0; yLevelPos < lines.Length; yLevelPos++)
        {
            

            Debug.Log(lines[yLevelPos]);

            string line = lines[yLevelPos].ToUpper();
            //makes a line into an array of chracters
            char[] characters = line.ToCharArray();
            for (int xLevelPos = 0; xLevelPos < characters.Length; xLevelPos++)
            {
                


                char c = characters[xLevelPos];

                Debug.Log(c);
                
                GameObject newObject = null;

                switch (c)
                {
                    //if the character is a W add a wall to our scene
                    case 'W': newObject = Instantiate(Resources.Load<GameObject>(path: "Prefabs/Wall"));
                        break;
                    //if the character is a P add a player to our scene
                    case 'P': newObject = Instantiate((Resources.Load<GameObject>(path: "Prefabs/Player")));
                        Camera.main.transform.parent = newObject.transform;
                        Camera.main.transform.position = new Vector3(0, 0, -10);
                        break;
                    
                    case 'S':
                        newObject = Instantiate((Resources.Load<GameObject>(path: "Prefabs/Spike")));
                        break;
                    
                    case 'G':
                        newObject = Instantiate((Resources.Load<GameObject>("Prefabs/Goal")));
                        break;
                }
                
                if (newObject != null)
                {
                    newObject.transform.parent = level.transform;
                    //Give it a position based on where it was in the ASCII file
                    newObject.transform.position = new Vector2(xLevelPos, -yLevelPos);
                }
                
                
                
                /* the old way with many ifs statements
                 if (c == 'W')
                {
                    //Instantiate whatever is in the  path
                    newObject = Instantiate(Resources.Load<GameObject>(path: "Prefabs/Wall"));
                }

                if (c == 'P')
                {
                    newObject = Instantiate(Resources.Load<GameObject>(path: "Prefabs/Player"));

                    Camera.main.transform.parent = newObject.transform;
                    Camera.main.transform.position = new Vector3(0, 0, -10);
                }
                */

               
                
                
                
                
            }
        }
    }

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MoveableObjects : MonoBehaviour
{
    
    // make a place to save the file
    private const string FILE_DIR = "/SAVE_DATA/";

    string FILE_NAME = "<name>.json";

    private string FILE_PATH;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_NAME = FILE_NAME.Replace("<name>", name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition();
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 result = Input.mousePosition;

        result.z = Camera.main.WorldToScreenPoint(transform.position).z;

        result = Camera.main.ScreenToWorldPoint(result);

        return result;
    }

    public void SaveGame()
    {
        string fileContent = JsonUtility.ToJson(transform.position, true);
        Debug.Log(fileContent);
        
        File.WriteAllText(FILE_PATH, fileContent);
        
        Debug.Log("you saved the game!");
    }

    public void LoaderLevel()
    {
        

        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;

        if (File.Exists(FILE_PATH))
        {
            string jsonString = File.ReadAllText(FILE_PATH);

            transform.position = JsonUtility.FromJson<Vector3>(jsonString);
        }
        
        Debug.Log("you loaded the game!");
        
    }
    
}

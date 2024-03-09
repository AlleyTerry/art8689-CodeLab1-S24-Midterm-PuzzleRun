using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI display;
    public int score;

    private const string FILE_DIR = "/DATA/";
    private const string DATA_FILE = "highScores.txt";
    private string FILE_FULL_PATH;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    private string highScoresString = "";

    List<int> highScores;

    public List<int> HighScores
    {
        get
        {
            if (highScores == null && File.Exists(FILE_FULL_PATH))
            {
                highScores = new List<int>();

                highScoresString = File.ReadAllText(FILE_FULL_PATH);

                highScoresString = highScoresString.Trim();

                string[] highScoreArray = highScoresString.Split("\n");

                for (int i = 0; i < highScoreArray.Length; i++)
                {
                    int currentScore = Int32.Parse(highScoreArray[i]);
                    highScores.Add((currentScore));
                }
             
            }
            else if (highScores == null)
            {
                Debug.Log("no current high scores");

                highScores = new List<int>();
                highScores.Add(3);
                highScores.Add(2);
                highScores.Add(1);
                highScores.Add(0);
                
            }

            return highScores;
        }

    }

    private float timer = 0;
    public int minTime = 10;

    private bool isInGame = true;
    public bool levelTimer = false;

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
        FILE_FULL_PATH = Application.dataPath + FILE_DIR + DATA_FILE;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInGame)
        {
            display.text = "Time: " + ((int)timer);
        }
        else
        {
            display.text = "Game Over \nTimes:\n" + highScoresString;;
        }

        if (!levelTimer)
        {
            timer += Time.deltaTime;
        }

    

        if (ASCIILevelLoader.instance.CurrentLevel == 5 && isInGame)
        {
            isInGame = false;
            levelTimer = true;
            SceneManager.LoadScene(5);
            SetHighScore();
            
        }
    }

    bool IsHighScore(int timer)
    {
        for (int i = 0; i < HighScores.Count; i++)
        {
            if (highScores[i] > timer)
            {
                return true;
            }
        }

        return false;
    }

    void SetHighScore()
    {
        if (IsHighScore((int)timer))
        {
            int highScoreSlot = -1;

            for (int i = 0; i < HighScores.Count; i++)
            {
                if (timer < highScores[i])
                {
                    highScoreSlot = i;
                    break;
                }
            }
            
            highScores.Insert(highScoreSlot, (int)timer);

            highScores = highScores.GetRange(0, 5);

            string scoreBoardText = "";

            foreach (var highScore in highScores)
            {
                scoreBoardText += highScore + "\n";
            }

            highScoresString = scoreBoardText;
            
            File.WriteAllText(FILE_FULL_PATH, highScoresString);


        }
    }
    
}

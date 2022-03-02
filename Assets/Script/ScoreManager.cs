using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public int score;
    public int highScore;

    public void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score",score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementalScore() 
    {
        score += 1 ;
    }

    public void StartScore()
    {
        InvokeRepeating("incrementalScore",0.1f,0.5f);
    }

    public void CancelScore()
    {
        CancelInvoke("StartScore");

        PlayerPrefs.SetInt("score",score);

        if(PlayerPrefs.HasKey("highScore")) {
            if(score > PlayerPrefs.GetInt("highScore")) {
                PlayerPrefs.SetInt("highScore",score);
            }
        }
        
        else {
            PlayerPrefs.SetInt("score",score);
        }           
    }
}

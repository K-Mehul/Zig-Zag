using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject gameOverPanel;
    public GameObject zigZagPanel;
    public GameObject tapToPlay;
    public Text score ;
    public Text highScore1;
    public Text highScore2;

    public void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
     highScore1.text = "High Score :" + PlayerPrefs.GetInt("highScore");    
    }

    public void GameStart()
    {
       
        tapToPlay.SetActive(false);
        zigZagPanel.GetComponent<Animator>().Play("panel");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("score").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

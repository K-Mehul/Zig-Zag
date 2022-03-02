using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public bool gameOver;
    public void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        ScoreManager.instance.StartScore();
        UiManager.instance.GameStart();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawning();
    }

    public void GameOver()
    {
        ScoreManager.instance.CancelScore();
        UiManager.instance.GameOver();
        gameOver = true;
    }
}

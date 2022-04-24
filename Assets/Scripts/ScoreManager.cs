using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0, highscore = 0;
    
    void Awake()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
    }
    void Start()
    {       
        changeHScore(); 
    }
    public delegate void chngHScoreHandler(int hScore);
    public static event chngHScoreHandler OnChangeHScore;

    private void changeHScore()
    {
        if(OnChangeHScore!=null)
        {
            OnChangeHScore(highscore);
        }
    }
    private void changeScore()
    {
        if (OnChangeScore != null)
        {
            OnChangeScore(score);
        }
    }
    public delegate void chngScoreHandler(int Score);
    public static event chngScoreHandler OnChangeScore;
    private void OnEnable()
    {
        GameManager.OnBirdDied += GameManager_OnBirdDied;
        GameManager.OnBirdScored += GameManager_OnBirdScored;
    }
    private void OnDisable()
    {
        GameManager.OnBirdDied -= GameManager_OnBirdDied;
        GameManager.OnBirdScored -= GameManager_OnBirdScored;
    }
    private void GameManager_OnBirdDied()
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            highscore = score;
            changeHScore();
        }
    }
    private void GameManager_OnBirdScored()
    {
        score++;
        changeScore();
    }
}

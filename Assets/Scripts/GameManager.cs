using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0,highscore=0;
    private Text[] scoreElements;
    private Text scoreText,highscoreText;
    
    void Awake()
    {
        highscore = PlayerPrefs.GetInt("highscore",0);
       // Debug.Log(PlayerPrefs.GetInt("highscore",0));
        if(instance==null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        scoreElements = FindObjectsOfType<Text>();
        for (int i = 0; i < scoreElements.Length; i++)
        {
            if(scoreElements[i].GetComponent<Text>().text== "")
            {
                scoreText = scoreElements[i];
                scoreText.text = "Score: 0";
            }
            else if(scoreElements[i].GetComponent<Text>().text== "HIGHSCORE:")
            {
                highscoreText = scoreElements[i];
                highscoreText.text = "HIGHSCORE: "+highscore.ToString();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(gameOver==true&&Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void BirdScored()
    {
        if(gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();        
    }
    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
        if(score>highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}

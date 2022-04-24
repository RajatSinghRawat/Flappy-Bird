using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text UIScoreText, UIHScoreText;
    [SerializeField] private GameObject UIGameOverText;

    // Start is called before the first frame update
    void Start()
    {
        UIScoreText = P_Score.getText();
        UIHScoreText = H_Score.getText();       
    }
    private void OnEnable()
    {
        ScoreManager.OnChangeHScore += SManager_OnChangeHScore;
        ScoreManager.OnChangeScore += SManager_OnChangeScore;
        GameManager.OnBirdDied += GameManager_OnBirdDied;
    }
    private void OnDisable()
    {
        ScoreManager.OnChangeHScore -= SManager_OnChangeHScore;
        ScoreManager.OnChangeScore -= SManager_OnChangeScore;
        GameManager.OnBirdDied -= GameManager_OnBirdDied;
    }
    private void SManager_OnChangeHScore(int hscore)
    {
        UIHScoreText.text = "HIGHSCORE: " + hscore.ToString();
    }
    private void SManager_OnChangeScore(int score)
    {
        UIScoreText.text = "Score: " + score.ToString();
    }
    private void GameManager_OnBirdDied()
    {
        UIGameOverText.SetActive(true);
    }
}

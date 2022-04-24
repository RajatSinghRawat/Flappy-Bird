using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private bool gameOver = false;
    private float scrollSpeed = -30f;

    void Awake()
    {     
        if(instance==null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOver==true&&Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public delegate void BirdScoredHandler();
    public static event BirdScoredHandler OnBirdScored;
    private void BirdScored()
    {
        if(gameOver)
        {
            return;
        }
        else if(OnBirdScored != null)
        {
            OnBirdScored();
        }
    }
    public static void B_Scored()
    {
        instance.BirdScored();
    }

    public delegate void BirdDiedHandler();
    public static event BirdDiedHandler OnBirdDied;
    private void BirdDied()
    {
        gameOver = true;
        if(OnBirdDied!=null)
        {
            OnBirdDied();
        }
    }
    public static void B_Died()
    {
        instance.BirdDied();
    }
    public static bool chkGameStatus()
    {
        return instance.gameOver;
    }
    public static float getScrollSpeed()
    {
        return instance.scrollSpeed;
    }  
}

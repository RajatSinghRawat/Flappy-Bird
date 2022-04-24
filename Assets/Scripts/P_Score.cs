using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_Score : MonoBehaviour
{
    private static P_Score instance;
    private Text scoreText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        scoreText = GetComponent<Text>();
    }
    public static Text getText()
    {
        return instance.scoreText;
    }
}

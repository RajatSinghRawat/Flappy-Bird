using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class H_Score : MonoBehaviour
{
    private static H_Score instance;
    private Text hscoreText;
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
        hscoreText = GetComponent<Text>();
    }
    public static Text getText()
    {
        return instance.hscoreText;
    }
}

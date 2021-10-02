using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public Transform ball;
    public Rigidbody2D Ball;
    public TMP_Text highscore;

    void Start()
    {
        highscore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score = Mathf.FloorToInt(10*ball.position.x);
        if (Ball.velocity.magnitude == 0 && PlayerPrefs.GetInt("HighScore", 0) < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscore.text = "Score: "+score+"\nHIGH SCORE: " + score.ToString();
            //call an event for showing highscore
        }
        else highscore.text = "Score: " + score + "\nHIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0);
    }
}

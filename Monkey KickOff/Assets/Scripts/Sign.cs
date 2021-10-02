using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Sign : MonoBehaviour
{
    public TMP_Text text;
    public Animator anim;
    public AudioSource grow;
    void Start() {
        anim.SetBool("Newhighscore",false);
        transform.position = new Vector2(PlayerPrefs.GetInt("HighScore", 0)/10, 0); 
        text.text = "Personal Best:\n" + PlayerPrefs.GetInt("HighScore", 0);
        if (PlayerPrefs.GetInt("HighScore", 0) == 0) transform.position = new Vector2(-100, 0); // Initially out of sight
    }
    
    public void PlaceBoard(Vector3 pos)
    { //Place sign showing high score at the new ball position
        transform.position = pos;
        anim.SetBool("Newhighscore",true);
        if (!grow.isPlaying) grow.Play();
    }
}

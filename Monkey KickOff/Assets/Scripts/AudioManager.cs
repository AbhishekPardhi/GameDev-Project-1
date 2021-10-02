using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Bounce;
    public AudioSource t1;
    public Transform ball;
    Ball b;
    void Start()
    {
        b = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ball.position.y < -0.3) Bounce.Play();
        if (b.isDribbling && ball.position.y<0.01 && !Bounce.isPlaying) Bounce.Play();
    }
}

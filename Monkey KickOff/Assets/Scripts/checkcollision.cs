using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkcollision : MonoBehaviour
{
    // Start is called before the first frame update
    AudioManager aud;
    void Start()
    {
        aud = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && !aud.Bounce.isPlaying) aud.Bounce.Play();
    }
}

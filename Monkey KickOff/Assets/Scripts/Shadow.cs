using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    // Start is called before the first frame update
    Ball ball;
    float x=1;
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ball.ball.transform.position.x,transform.position.y,transform.position.z);
        x = (float)(1 - 0.6 * ball.ball.transform.position.y / 70);
        gameObject.transform.localScale = new Vector3(x,x,x);
    }
}

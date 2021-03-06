using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    public GameObject bg4;
    public GameObject bg5;

    public Sprite forest;
    public Sprite desert;
    public Sprite city;
    public Sprite space;

    public Rigidbody2D ball;
    public Camera cam;

    private float offset = 10.66f;
    private float relVel = 0.0f;
    private Queue<GameObject> backgrounds = new Queue<GameObject>();

    void Start()
    {
        SetBg(bg1, forest);
        SetBg(bg2, forest);
        SetBg(bg3, forest);
        SetBg(bg4, forest);
        SetBg(bg5, forest);
        cam = FindObjectOfType<Camera>();
        backgrounds.Enqueue(bg1);
        backgrounds.Enqueue(bg2);
        backgrounds.Enqueue(bg3);
        backgrounds.Enqueue(bg4);
        backgrounds.Enqueue(bg5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        relVel = ball.velocity.x/2;
        foreach(GameObject bg in backgrounds) {
            bg.transform.position += Vector3.right * (ball.velocity.x - relVel) * Time.fixedDeltaTime;
        }

        if(cam.transform.position.x - backgrounds.Peek().transform.position.x > 5*offset/2) {
            GameObject temp = backgrounds.Dequeue();
            if(cam.transform.position.x > 90) {
                SetBg(temp, desert);
                temp.transform.position = new Vector3(temp.transform.position.x, 1.90f, 2);
            }
            if(cam.transform.position.x > 180) {
                SetBg(temp, city);
                temp.transform.position = new Vector3(temp.transform.position.x, 1.56f, 2);
            }
            if(cam.transform.position.x > 270) {
                SetBg(temp, space);
                temp.transform.position = new Vector3(temp.transform.position.x, 1.92f, 2);
            }
            temp.transform.position += new Vector3(4*offset, 0, 0);
            backgrounds.Enqueue(temp);
        }
        
    }
    void SetBg(GameObject bg, Sprite map)
    {
        bg.GetComponent<SpriteRenderer>().sprite = map;
    }
}

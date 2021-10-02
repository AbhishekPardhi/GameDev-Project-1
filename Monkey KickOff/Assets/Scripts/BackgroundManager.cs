using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    public Sprite map1;
    public Sprite map2;
    public Sprite map3;
    public Sprite map4;
    public Transform ball;
    public Camera cam;
    void Start()
    {
        SetBg(bg1, map1);
        SetBg(bg2, map1);
        SetBg(bg3, map1);
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cam.transform.position.x>(bg2.transform.position.x+ bg3.transform.position.x)/2)
        {
            bg1.transform.position += new Vector3(10, 0, 0);
            bg2.transform.position += new Vector3(10, 0, 0);
            bg3.transform.position += new Vector3(10, 0, 0);
        }
        if (cam.transform.position.x > 85) SetBg(bg3, map2);
        if (cam.transform.position.x > 95) SetBg(bg2, map2);
        if (cam.transform.position.x > 105) SetBg(bg1, map2);
        if (cam.transform.position.x > 185) SetBg(bg3, map3);
        if (cam.transform.position.x > 195) SetBg(bg2, map3);
        if (cam.transform.position.x > 205) SetBg(bg1, map3);
        if (cam.transform.position.x > 285) SetBg(bg3, map4);
        if (cam.transform.position.x > 295) SetBg(bg2, map4);
        if (cam.transform.position.x > 305) SetBg(bg1, map4);
    }
    void SetBg(GameObject bg, Sprite map)
    {
        bg.GetComponent<SpriteRenderer>().sprite = map;
    }
}

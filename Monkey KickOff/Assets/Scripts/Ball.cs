using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    float height;
    public Rigidbody2D ball;
    private float h;
    public Transform Base;
    public Transform DribblePoint;
    public Camera cam;
    public float C0;
    public float C1;
    public float C3;
    public float x;
    public bool isDribbling=true;
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && isDribbling)
        {
            isDribbling = false;
            Impulse();
        }
        if (transform.position.y <= DribblePoint.position.y && isDribbling) Dribble();
        if (!isDribbling && ball.velocity.x < 0.01)
        {
            ball.velocity = new Vector3(0, 0);
            StartCoroutine(loadscene(1f));
        }
        cam.transform.position = new Vector3(transform.position.x,0,-10);
    }
    IEnumerator loadscene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
    void Impulse()
    {
        h = (float)(ball.position.y - 0.6-Base.position.y);
        ball.velocity = new Vector2(6+C0 * (C1 + ball.velocity.magnitude * C3 / Mathf.Sqrt(1 + h * h)), 2*(6+16*h+C0 * (C1 + ball.velocity.magnitude * C3) * h / Mathf.Sqrt(1 + h * h)));
    }
    void Dribble()
    {
        FindHeight();
        ball.velocity = new Vector2(0, Mathf.Sqrt(2*x* ball.gravityScale * height));
    }
    void FindHeight()
    {
        height = Random.Range(3, 11) / 5;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monke : MonoBehaviour
{
    private Animator monke;
    private Transform monke_T;

    void Start() {
        monke = GetComponent<Animator>();
        monke_T = GetComponent<Transform>();
    }

    public void startKick() {
        monke.SetBool("hasKicked", true);
        //monke_T.position = new Vector3(-1, 0.3f, 0);
    }
}

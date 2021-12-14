using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flute : MonoBehaviour
{
    public AudioSource D;
    public float time;
    bool up;

    private void Start()
    {
        D = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (up)
        {
            D.volume -= Time.deltaTime * time;
        }
        
    }
    public void Up()
    {
        up = true; 
    }
    public void Down()
    {
        up = false;
        D.volume = 1;
        D.Play();   
    }
}

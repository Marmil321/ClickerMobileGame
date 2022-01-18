using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePrice : MonoBehaviour
{
    public int result;
    public int prefs;

    private int number;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            result = 0;
            Test();
        }
    }
    void Test()
    {
       if(prefs - 5  >= 0)
        {
            result++;
            prefs -= 5;
            Test();
        }
    }
}

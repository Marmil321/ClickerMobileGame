using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideColllider : MonoBehaviour
{
    [SerializeField] GameObject[] menus;
    public Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (menus[0].GetComponent<Canvas>().isActiveAndEnabled)
        {
            col.enabled = false;
        }else if (menus[1].GetComponent<Canvas>().isActiveAndEnabled)
        {
            col.enabled = false;
        }else if (menus[2].activeInHierarchy)
        {
            col.enabled = false;
        }else if (menus[3].activeInHierarchy)
        {
            col.enabled = false;
        }
        else
        {
            col.enabled = true;
        }
       
    }
}

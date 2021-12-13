using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AxeScript : MonoBehaviour
{
    public Click click;
    int durability = 100;
    int maxDurability = 100;
    public TextMeshProUGUI text;

    private void Awake()
    {
        click = GameObject.Find("Tree").GetComponent<Click>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = durability.ToString() + "/" + maxDurability.ToString();
    }
    public void AxeClick()
    {
        durability--;
    }
}

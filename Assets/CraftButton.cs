using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftButton : MonoBehaviour
{
    public Slider bar;
    public TMP_Text text;

    [SerializeField] float speed;
    float countdown = 0;

    public DisplayCrafting crafting;

    private void Start()
    {
        crafting = FindObjectOfType<DisplayCrafting>();
    }
    private void Update()
    {
        text.text = bar.value.ToString() + "%";
        countdown = Mathf.Clamp(countdown, 0,101);
        countdown -= speed * Time.deltaTime;
        bar.value = countdown;
        
        if(bar.value == 100)
        {
            countdown = 0;
            print("crafted");
            crafting.Craft();
        }
    }
    public void Button()
    {
        countdown += 25;
    }
}

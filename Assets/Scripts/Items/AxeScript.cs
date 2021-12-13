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

    ItemManager itemManager;

    private void Awake()
    {
        itemManager = FindObjectOfType<ItemManager>();
        click = GameObject.Find("Tree").GetComponent<Click>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = durability.ToString() + "/" + maxDurability.ToString();
        if (durability <= 0)
        {
            this.gameObject.SetActive(false);
            durability = maxDurability;
            itemManager.usingAxe = false;
        }
    }
    public void AxeClick()
    {
        durability--;
    }
}

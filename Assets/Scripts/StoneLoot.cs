using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneLoot : MonoBehaviour
{
    public int amount;

    private void Start()
    {

    }
    private void Update()
    {
        amount = PlayerPrefs.GetInt("BronzeOreAmount");
    }
    private void OnMouseDown()
    {
        int getIronOre = Random.Range(0,26);

        if (getIronOre == 25)
        {
            amount++;
            PlayerPrefs.SetInt("BronzeOreAmount", amount);
        }
    }
}

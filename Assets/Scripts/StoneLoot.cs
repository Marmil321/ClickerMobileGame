using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneLoot : MonoBehaviour
{
    public int amount;
    public Text ironAmountText;

    private void Start()
    {

    }
    private void Update()
    {
        amount = PlayerPrefs.GetInt("IronAmount");

        ironAmountText.text = amount.ToString();
    }
    private void OnMouseDown()
    {
        int getIron = Random.Range(0,26);

        if (getIron == 25)
        {
            amount++;
            PlayerPrefs.SetInt("IronAmount", amount);
        }
    }
}

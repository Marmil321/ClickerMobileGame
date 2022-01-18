using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftingBox : MonoBehaviour
{
    public InventoryManager inv;
    public InventoryText invText;

    [SerializeField] string[] materials;
    List<TMP_Text> amount = new List<TMP_Text>();

    private void Start()
    {
        inv = FindObjectOfType<InventoryManager>();
        invText = FindObjectOfType<InventoryText>();
    }
    private void FixedUpdate()
    {
        DisplayText();
    }
    void DisplayText()
    {
        amount.Clear();

        for (int i = 0; i < materials.Length; i++)
        {
            amount.Add(transform.Find(materials[i]).GetComponentInChildren<TMP_Text>());
            amount[i].text = invText.ShortenNumber(PlayerPrefs.GetInt(materials[i] + "Amount")) + " /10";
        }
    }
}

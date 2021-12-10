using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInteraction : MonoBehaviour
{
    private int selected = 0;

    public void Button()
    {
       selected = GetItemID(GetComponent<Image>().sprite);

        foreach (GameObject frame in GameObject.FindGameObjectsWithTag("Frame"))
        {
            frame.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);
    }
    private int GetItemID(Sprite sprite)
    {
        switch (sprite.name)
        {
            default:         return 0;
            case "stoneAxe": return 1;
            case "coal":     return 2;
            case "none":     return 3;
        }
    }
    private void OnDisable()
    {
        //transform.GetChild(0).gameObject.SetActive(false);
        selected = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugScript : MonoBehaviour
{
    public void Set9999()
    {
        PlayerPrefs.SetInt("StoneAmount", 9999);
        FindObjectOfType<InventoryManager>().Add("IronAmount", 100000);
        FindObjectOfType<InventoryManager>().Add("WoodAmount", 100000);
        FindObjectOfType<InventoryManager>().Add("StickAmount",1000);
        FindObjectOfType<InventoryManager>().Add("CoalAmount", 1000);
        FindObjectOfType<InventoryManager>().Add("CopperAmount", 1000);
    }
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
    public void OneCopper()
    {
        int newValue = PlayerPrefs.GetInt("CopperAmount") + 1;
        FindObjectOfType<InventoryManager>().Add("CopperAmount", newValue);
    }
    public void HundredAxes()
    {
        int newValue = PlayerPrefs.GetInt("AutoWood") + 100;
        PlayerPrefs.SetInt("AutoWood", newValue);
    }
}

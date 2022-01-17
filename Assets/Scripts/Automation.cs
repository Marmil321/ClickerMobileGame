using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automation : MonoBehaviour
{
    InventoryManager inv;
    UpgradeManger upgrades;

    private void Start()
    {
        inv = GetComponent<InventoryManager>();
        upgrades = GetComponent<UpgradeManger>();

        loop();
    }
    private void loop()
    {
        StartCoroutine(AutoFarmWood());
        StartCoroutine(AutoFarmStone());
    }
    private int AutoAmount(string material, int index)
    {
        return PlayerPrefs.GetInt("Auto" + material) * upgrades.upgradeAmounts[index];
    }
    IEnumerator AutoFarmWood()
    {
        yield return new WaitForSeconds(1);
        inv.Add("WoodAmount", AutoAmount("Wood", 0));

        loop();
    }
    IEnumerator AutoFarmStone()
    {
        yield return new WaitForSeconds(1);
        inv.Add("StoneAmount", AutoAmount("Stone", 1));
    }
    
}

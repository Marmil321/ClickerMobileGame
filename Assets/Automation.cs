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
    IEnumerator AutoFarmWood()
    {
        yield return new WaitForSeconds(1);
        inv.Add("WoodAmount", PlayerPrefs.GetInt("AutoWood") * upgrades.upgradeAmounts[0]);

        loop();
    }
    IEnumerator AutoFarmStone()
    {
        yield return new WaitForSeconds(1);
        inv.Add("StoneAmount", PlayerPrefs.GetInt("AutoStone") * upgrades.upgradeAmounts[1]);
    }
}

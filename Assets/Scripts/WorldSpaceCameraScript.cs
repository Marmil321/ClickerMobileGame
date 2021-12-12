using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceCameraScript : MonoBehaviour
{
    public Button smeltIronButton;
    public GameObject furnace;
    public GameObject cooldownBar;

    public Vector3[] offsets;

    public InventoryManager inv;
    //Materials
    int wood;
    int stone;
    int iron;

    private void Update()
    {
        wood = PlayerPrefs.GetInt("WoodAmount");
        stone = PlayerPrefs.GetInt("StoneAmount");
        iron = PlayerPrefs.GetInt("IronAmount");

        inv = FindObjectOfType<InventoryManager>();
        smeltIronButton.gameObject.transform.position = furnace.transform.position + offsets[0];
    }

    public void SmeltIron()
    {
        if (wood >= inv.coal && inv.iron >= 1)
        {
            inv.RemoveMaterial("CoalAmount", 1);
            inv.RemoveMaterial("IronAmount", 1);

            smeltIronButton.gameObject.SetActive(false);
            StartCoroutine(StartSmelt("IronAmount",inv.iron,15));
        }
    }
    IEnumerator StartSmelt(string output, int i, float cooldown)
    {
        GameObject bar = Instantiate(cooldownBar, furnace.transform.position + offsets[1], Quaternion.Euler(new Vector3(0,0,-90)));
        bar.GetComponentInChildren<CooldownBar>().time = cooldown;
        bar.transform.SetParent(furnace.transform);
        yield return new WaitForSeconds(cooldown);
        PlayerPrefs.SetInt(output, i + Random.Range(2,5));
        smeltIronButton.gameObject.SetActive(true);
    }
}

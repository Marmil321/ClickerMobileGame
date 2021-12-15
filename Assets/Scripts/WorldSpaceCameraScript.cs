using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceCameraScript : MonoBehaviour
{
    public Button smeltIronButton;
    public Image axeIcon;
    public GameObject furnace, tree;
    public GameObject cooldownBar;
    [SerializeField]private GameObject row;
    private int stage;

    public Vector3[] offsets;

    public InventoryManager inv;
    //Materials
    int wood;

    private void Update()
    {
        wood = PlayerPrefs.GetInt("WoodAmount");

        inv = FindObjectOfType<InventoryManager>();
        smeltIronButton.gameObject.transform.position = furnace.transform.position + offsets[0];
        //row.transform.position = smeltIronButton.gameObject.transform.position;
        axeIcon.gameObject.transform.position = tree.transform.position + offsets[2];

        switch (stage)
        {
            case 0:
                if (row.transform.position != offsets[3])
                {
                    row.transform.position = Vector3.MoveTowards(row.transform.position, offsets[3], 5f * Time.deltaTime);
                }
                break;
            case 1:
                if (row.transform.position != offsets[4])
                {
                    row.transform.position = Vector3.MoveTowards(row.transform.position, offsets[4], 5f * Time.deltaTime);
                }
                break;
        }
    }

    public void SmeltIron()
    {
        if (wood >= inv.coal && inv.ironOre >= 1)
        {
            inv.RemoveMaterial("CoalAmount", 1);

            smeltIronButton.gameObject.SetActive(false);
            StartCoroutine(StartSmelt("IronAmount",inv.iron,5));
        }
    }
    IEnumerator StartSmelt(string output, int i, float cooldown)
    {
        GameObject bar = Instantiate(cooldownBar, furnace.transform.position + offsets[1], Quaternion.Euler(new Vector3(0,0,-90)));
        bar.GetComponentInChildren<CooldownBar>().time = cooldown;
        bar.transform.SetParent(furnace.transform);

        yield return new WaitForSeconds(cooldown);
        inv.RemoveMaterial("IronOreAmount", 1);
        PlayerPrefs.SetInt(output, i + 1);
        smeltIronButton.gameObject.SetActive(true);
    }
    public void Next()
    {
        if(stage < 1)
        {
            stage++;
        }
    }
    public void Prev()
    {
        if (stage > 0)
        {
            stage--;
        }
    }
}

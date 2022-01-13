using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceCanvasScript : MonoBehaviour
{
    public Button smeltCopperButton;
    public Image axeIcon;
    public GameObject furnace, tree;
    public GameObject cooldownBar;
    [SerializeField]private GameObject row;
    public int stage;

    public Vector3[] offsets;

    public InventoryManager inv;

    private void Update()
    {
        inv = FindObjectOfType<InventoryManager>();
        smeltCopperButton.gameObject.transform.position = furnace.transform.position + offsets[0];
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
            case 2:
                if (row.transform.position != offsets[5])
                {
                    row.transform.position = Vector3.MoveTowards(row.transform.position, offsets[5], 5f * Time.deltaTime);
                }
                break;
        }
    }

    public void SmeltCopper()
    {
        if (inv.coal > 0 && inv.copperOre >= 1)
        {
            inv.RemoveMaterial("CoalAmount", 1);

            smeltCopperButton.gameObject.SetActive(false);
            StartCoroutine(StartSmelt("CopperAmount",inv.copper,5));
        }
    }
    IEnumerator StartSmelt(string output, int i, float cooldown)
    {
        GameObject bar = Instantiate(cooldownBar, furnace.transform.position + offsets[1], Quaternion.Euler(new Vector3(0,0,-90)));
        bar.GetComponentInChildren<CooldownBar>().time = cooldown;
        bar.transform.SetParent(furnace.transform);

        yield return new WaitForSeconds(cooldown);
        inv.RemoveMaterial("CopperOreAmount", 1);
        PlayerPrefs.SetInt(output, i + 1);
        smeltCopperButton.gameObject.SetActive(true);
    }
    public void Next()
    {
        if(stage < 2)
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

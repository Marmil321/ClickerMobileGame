using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseInventory : MonoBehaviour
{
    public Animator anim, iconAnim;
    public string animObj;
    [SerializeField] GameObject icon;

    void Start()
    {
        anim = transform.Find(animObj).GetComponent<Animator>();
        iconAnim = icon.GetComponent<Animator>();
    }

   public void Open()
    {
        anim.Play("InventoryDown");
        GetComponent<Canvas>().enabled = true;

        iconAnim.Play("BackpackClick");

        if(animObj == "wholecrafting")
        {
            
        }else if(animObj == "wholeinventory")
        {

        }
    }
    public void Close()
    {
        anim.Play("InventoryUp");
        StartCoroutine(CloseTimer());

        if (animObj == "wholecrafting")
        {

        }
        else if (animObj == "wholeinventory")
        {

        }
    }
    public IEnumerator CloseTimer()
    {
        yield return new WaitForSeconds(.5f);
        GetComponent<Canvas>().enabled = false;
    }
}

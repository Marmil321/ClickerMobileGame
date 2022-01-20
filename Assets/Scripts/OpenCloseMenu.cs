using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseMenu : MonoBehaviour
{
    public Animator anim, iconAnim;
    public string animObj;
    [SerializeField] GameObject icon;

    void Start()
    {
        anim = transform.Find(animObj).GetComponent<Animator>();
        //iconAnim = icon.GetComponent<Animator>();
    }

   public void Open()
    {
        anim.Play("MenuDown");
        GetComponent<Canvas>().enabled = true;

        //iconAnim.Play("BackpackClick");

        if(animObj == "wholecrafting")
        {
            GameObject.Find("wholeinventory").GetComponent<Animator>().Play("MenuUp");
        }
        else if(animObj == "wholeinventory")
        {
            GameObject.Find("wholecrafting").GetComponent<Animator>().Play("MenuUp");
        }
    }
    public void Close()
    {
        anim.Play("MenuUp");
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

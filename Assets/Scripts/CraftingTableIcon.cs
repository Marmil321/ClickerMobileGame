using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTableIcon : MonoBehaviour
{
    public Animator anim;
    public Canvas craftingCanvas;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        anim.Play("CraftingTableClick");
    }
    private void OnMouseUp()
    {
        craftingCanvas.gameObject.SetActive(true);
    }
    public void OpenCraft()
    {
        //anim.Play("CraftingTableClick");
        craftingCanvas.gameObject.SetActive(true);
    }
}

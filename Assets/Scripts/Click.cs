using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public Animator anim;
    public bool click;
    public Text textAmount;
    private int amount;
    public string material;
    public ParticleSystem leaves;

    public UpgradeManger upgrade;
    
    void Awake()
    {
        leaves = GetComponentInChildren<ParticleSystem>();
        material += "Amount";
        anim = GetComponent<Animator>();

        upgrade = FindObjectOfType<UpgradeManger>();
    }
    void OnMouseDown()
    {
        click = true;
    }
    void Update()
    {
        if (GameObject.Find("CraftingCanvas").GetComponent<Canvas>().enabled)
        {
            this.GetComponent<Collider2D>().enabled = false;
        }else
        {
            this.GetComponent<Collider2D>().enabled = true;
        }

        amount = PlayerPrefs.GetInt(material);

        textAmount.text = amount.ToString();

        if (click)
        {
            amount += upgrade.GetLevel();
            PlayerPrefs.SetInt(material, amount);
            anim.Play("ClickAnim");
            leaves.Play();
            if (this.gameObject.name == "Tree")
            {
                GameObject.Find("AxeIcon").GetComponent<AxeScript>().AxeClick();
            }
            click = false;
        }
    }
}

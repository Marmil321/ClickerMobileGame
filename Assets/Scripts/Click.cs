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
    public UIScript ui;
    
    void Awake()
    {
        ui = FindObjectOfType<UIScript>();
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
        /*if (GameObject.Find("CraftingCanvas").GetComponent<Canvas>().enabled)
        {
            this.GetComponent<Collider2D>().enabled = false;
        }else
        {
            this.GetComponent<Collider2D>().enabled = true;
        }*/

        amount = PlayerPrefs.GetInt(material);

        textAmount.text = amount.ToString();

        if (click)
        {
            amount += upgrade.GetLevel();
            PlayerPrefs.SetInt(material, amount);        
            leaves.Play();
            if(this.gameObject.name == "Stone" && ui.page == 1)
            {
                anim.Play("ClickAnim");
            }
            if (this.gameObject.name == "Tree" && ui.page == 0)
            {           
                anim.Play("TreeClick");
                if (GameObject.Find("AxeIcon"))
                {
                    GameObject.Find("AxeIcon").GetComponent<AxeScript>().AxeClick();
                    amount += upgrade.GetLevel();
                }
            }
            click = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstItem : MonoBehaviour
{
    [SerializeField] GameObject newItem;
    [SerializeField] GameObject itemAnim;

    [SerializeField] TMP_Text tmpro;

    public Animator anim;

    public Sprite[] itemSprites;

    private void Start()
    {
        anim = transform.Find("ItemAnimation").GetComponent<Animator>();
    }
    public void NewItem(int index, string item, string text)
    {
        if(PlayerPrefs.GetInt("has" + item) == 0)
        {
            itemAnim.transform.Find("item").GetComponent<Image>().sprite = itemSprites[index];
            tmpro.text = text;
            itemAnim.gameObject.SetActive(true);
            newItem.gameObject.SetActive(true);
            StartCoroutine(EnableButton());
            //PlayerPrefs.SetInt("has" + item, 1);
        }
        
    }
    IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(1.5f);
        newItem.GetComponent<Button>().interactable = true;
    }
    public void closeScreen()
    {
        newItem.gameObject.SetActive(false);
        StartCoroutine(PickUpAnim());
    }

    IEnumerator PickUpAnim()
    {
        anim.Play("PickUpItem");
        yield return new WaitForSeconds(1.25f);
        newItem.GetComponent<Button>().interactable = false;
        itemAnim.gameObject.SetActive(false);
    }
}

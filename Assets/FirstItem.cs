using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstItem : MonoBehaviour
{
    [SerializeField] GameObject newItem;
    [SerializeField] GameObject itemAnim;

    public Animator anim;

    public Sprite[] itemSprites;

    private void Start()
    {
        anim = transform.Find("ItemAnimation").GetComponent<Animator>();
    }
    public void NewItem(int index, string item)
    {
        if(PlayerPrefs.GetInt("has" + item) == 0)
        {
            itemAnim.transform.Find("item").GetComponent<Image>().sprite = itemSprites[index];
            itemAnim.gameObject.SetActive(true);
            newItem.gameObject.SetActive(true);
            PlayerPrefs.SetInt("has" + item, 1);
        }
        
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
        itemAnim.gameObject.SetActive(false);
    }
}

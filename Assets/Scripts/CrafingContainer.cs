using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafingContainer : MonoBehaviour
{
    public RectTransform rectTransform;
    public int craftable;
    public float rectHeight;
    public float rectPos;
    public float amount;

    public Transform startPos;
    public GameObject item;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectHeight = rectTransform.sizeDelta.y;
        rectPos = rectTransform.position.y;
        CheckCraftable();
    }
    public void CheckCraftable()
    {        
        for (int i = 0; i < amount; i++)
        {
            GameObject ins = Instantiate(item, transform.position = new Vector2(startPos.position.x, startPos.position.y), Quaternion.identity);
            ins.transform.SetParent(this.transform);
            ins.transform.position = new Vector2(startPos.position.x, (startPos.position.y + (amount * 100)) - (i * 200));
        }

        rectTransform.position = new Vector2(rectTransform.position.x, rectPos - (amount * 50));
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectHeight + (amount * 200));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {         
            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CheckCraftable();
        }
    }
}
public class Crafting
{
    public int stoneReq;
    public int woodReq;
    public int ironReq;
}

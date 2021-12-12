using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
   public enum ItemType
    {
        StoneAxe,
        Food,
        Coal,
        Pickaxe,
        test,
        xd,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:                return ItemAssets.Instance.none;
            case ItemType.StoneAxe: return ItemAssets.Instance.axeSprite;
            case ItemType.Coal:     return ItemAssets.Instance.coalSprite;
        }
    }

    public bool isStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Coal:
                return true;
            case ItemType.StoneAxe:
                return false;
        }
    }

}

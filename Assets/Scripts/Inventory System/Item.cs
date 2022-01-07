using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
   public enum ItemType
    {
        CopperAxe,
        CopperPickaxe
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:                        return ItemAssets.Instance.none;
            case ItemType.CopperAxe:        return ItemAssets.Instance.CopperAxe;
            case ItemType.CopperPickaxe:    return ItemAssets.Instance.CopperPickaxe;
        }
    }

    public bool isStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.CopperAxe:
                return false;
        }
    }

}

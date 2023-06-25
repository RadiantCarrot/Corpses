using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopStatsScript
{
    public string shopItemId { get; }
    public Sprite shopItemSprite { get; }
    public string weaponId { get; }
    public string weaponName { get; }
    public int unlockLevel { get; }
    public int goldRequirement { get; }

    public ShopStatsScript(string shopItemId, Sprite shopItemSprite, string weaponId, string weaponName, int unlockLevel, int goldRequirement)
    {
        this.shopItemId = shopItemId;
        this.shopItemSprite = shopItemSprite;
        this.weaponId = weaponId;
        this.weaponName = weaponName;
        this.unlockLevel = unlockLevel;
        this.goldRequirement = goldRequirement;
    }
}

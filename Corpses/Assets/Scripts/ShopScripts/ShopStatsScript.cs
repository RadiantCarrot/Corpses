using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class ShopStatsScript
{
    public string shopItemId { get; }
    public string shopItemSprite { get; }
    public string weaponId { get; }
    public string weaponName { get; }
    public int unlockLevel { get; }
    public int goldRequirement { get; }

    public ShopStatsScript(string shopItemId, string shopItemSprite, string weaponId, string weaponName, int unlockLevel, int goldRequirement)
    {
        this.shopItemId = shopItemId;
        this.shopItemSprite = shopItemSprite;
        this.weaponId = weaponId;
        this.weaponName = weaponName;
        this.unlockLevel = unlockLevel;
        this.goldRequirement = goldRequirement;
    }
}

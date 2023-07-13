using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class WeaponStatsScript
{
    public string weaponId { get; }
    public string weaponName { get; }
    public string weaponSprite { get; }
    public float attackInterval { get; }
    public string attackType { get; }

    public int projectileDamage { get; }
    public float projectileSpeed { get; }
    public string projectileType { get; }
    public float despawnTime { get; }

    public bool startEquipped { get; }

    //public int unlockLevel;
    //public int goldRequirement;

    public WeaponStatsScript( string weaponId, string weaponName, string weaponSprite, float attackInterval, string attackType, int projectileDamage, float projectileSpeed, string projectileType, float despawnTime, bool startEquipped)
    {
        this.weaponId = weaponId;
        this.weaponName = weaponName;
        this.weaponSprite = weaponSprite;
        this.attackInterval = attackInterval;
        this.attackType = attackType;
        this.projectileDamage = projectileDamage;
        this.projectileSpeed = projectileSpeed;
        this.projectileType = projectileType;
        this.despawnTime = despawnTime;
        this.startEquipped = startEquipped;
    }


    // Start is called before the first frame update
    void Start()
    {
        //itemName = gameObject.name; // assign name
        //itemSprite = gameObject.GetComponent<Sprite>(); // assign sprite
        //unlockLevel = 5; // assign unlockLevel
        //goldRequirement = 10; // assign goldRequirement
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

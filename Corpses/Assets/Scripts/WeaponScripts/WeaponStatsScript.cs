using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatsScript
{
    public string weaponId { get; }
    public string weaponName { get; }
    public Sprite weaponSprite { get; }
    public float attackInterval { get; }
    public int projectileDamage { get; }
    public float projectileSpeed { get; }
    public float despawnTime { get; }

    //public int unlockLevel;
    //public int goldRequirement;

    public WeaponStatsScript( string weaponId, string weaponName, Sprite weaponSprite, float attackInterval, int projectileDamage, float projectileSpeed, float despawnTime)
    {
        this.weaponId = weaponId;
        this.weaponName = weaponName;
        this.weaponSprite = weaponSprite;
        this.attackInterval = attackInterval;
        this.projectileDamage = projectileDamage;
        this.projectileSpeed = projectileSpeed;
        this.despawnTime = despawnTime;
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

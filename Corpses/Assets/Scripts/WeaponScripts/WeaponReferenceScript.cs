using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class WeaponReferenceScript
{
    public string weaponId;
    public string weaponName;
    public Sprite weaponSprite;
    public float attackInterval;
    public string attackType;
    public int projectileDamage;
    public float projectileSpeed;
    public string projectileType;
    public float despawnTime;
    public bool startEquipped;
}

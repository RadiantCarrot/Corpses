using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

// Done by KarLonng

public class EnemyReferenceScript
{
    public string enemyId;
    public string enemyName;
    public string enemySprite;
    public int enemyHealth;
    public float enemySpeed;
    public int enemyDamage;

    public float projectileSpeed;   
    public int projectileDamage;

    public float aggroDistance;
    public float attackDistance;
    public float retreatDistance;

    public int enemyGold;
    public int enemyXp;

    public bool isRanged;
}

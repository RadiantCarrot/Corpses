using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyReferenceScript
{
    public string enemyId;
    public string enemyName;
    public Sprite enemySprite;
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
}

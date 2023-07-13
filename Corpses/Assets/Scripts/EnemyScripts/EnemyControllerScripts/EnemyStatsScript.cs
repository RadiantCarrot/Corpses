using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class EnemyStatsScript
{
    public string enemyId { get; }
    public string enemyName { get; }
    public string enemySprite { get; }
    public int enemyHealth { get; }
    public float enemySpeed { get; }
    public int enemyDamage { get; }

    public float projectileSpeed { get; }
    public int projectileDamage { get; }

    public float aggroDistance { get; }
    public float attackDistance { get; }
    public float retreatDistance { get; }

    public int enemyGold { get; }
    public int enemyXp { get; }


    public bool isRanged { get; }


    public EnemyStatsScript (string enemyId, string enemyName, string enemySprite, int enemyHealth, float enemySpeed, int enemyDamage, float projectileSpeed, int projectileDamage, float aggroDistance, float attackDistance, float retreatDistance, int enemyGold, int enemyXp, bool isRanged)
    {
        this.enemyId = enemyId;
        this.enemyName = enemyName;
        this.enemySprite = enemySprite;
        this.enemyHealth = enemyHealth;
        this.enemySpeed = enemySpeed;
        this.enemyDamage = enemyDamage;
        this.projectileSpeed = projectileSpeed;
        this.projectileDamage = projectileDamage;
        this.aggroDistance = aggroDistance;
        this.attackDistance = attackDistance;
        this.retreatDistance = retreatDistance;
        this.enemyGold = enemyGold;
        this.enemyXp = enemyXp;
        this.isRanged = isRanged;
    }
}

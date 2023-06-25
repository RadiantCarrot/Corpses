using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataAccessScript
{
    private static List<WeaponStatsScript> weaponList;
    private static List<EnemyStatsScript> enemyList;
    private static List<ShopStatsScript> shopItemList;
    private static List<DialogueScript> dialogueList;



    public static List<WeaponStatsScript> GetWeaponList()
    {
        return weaponList;
    }

    public static void SetWeaponList (List<WeaponStatsScript> wList)
    {
        weaponList = wList;
    }

    public static WeaponStatsScript GetWeaponById (string weaponId)
    {
        return weaponList.Find(i  => i.weaponId == weaponId);
    }



    public static List<EnemyStatsScript> GetEnemyList()
    {
        return enemyList;
    }

    public static void SetEnemyList(List<EnemyStatsScript> eList)
    {
        enemyList = eList;
    }
    public static EnemyStatsScript GetEnemyById(string enemyId)
    {
        return enemyList.Find(i => i.enemyId == enemyId);
    }



    public static List<ShopStatsScript> GetShopItemList()
    {
        return shopItemList;
    }

    public static void SetShopList(List<ShopStatsScript> sItemList)
    {
        shopItemList = sItemList;
    }

    public static ShopStatsScript GetShopItemById(string shopItemId)
    {
        return shopItemList.Find(i => i.shopItemId == shopItemId);
    }



    public static List<DialogueScript> GetDialogueList()
    {
        return dialogueList;
    }

    public static void SetDialogueList(List<DialogueScript> dList)
    {
        dialogueList = dList;
    }

    public static DialogueScript GetDialogueById(string dialogueId)
    {
        return dialogueList.Find(i => i.dialogueId == dialogueId);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng
public static class DataAccessScript
{
    public static List<PlayerStatsScript> playerList;
    public static List<WeaponStatsScript> weaponList;
    public static List<EnemyStatsScript> enemyList;
    public static List<WaveStatsScript> waveList;
    public static List<TimerStatsScript> timerList;
    public static List<ShopStatsScript> shopItemList;
    public static List<DialogueScript> dialogueList;



    public static List<PlayerStatsScript> GetPlayerList()
    {
        return playerList;
    }

    public static void SetPlayerList(List<PlayerStatsScript> pList)
    {
        playerList = pList;
    }



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



    public static List<WaveStatsScript> GetWaveList()
    {
        return waveList;
    }

    public static void SetWaveList(List<WaveStatsScript> wList)
    {
        waveList = wList;
    }



    public static List<TimerStatsScript> GetTimerList()
    {
        return timerList;
    }

    public static void SetTimerList(List<TimerStatsScript> tList)
    {
        timerList = tList;
    }



    public static List<ShopStatsScript> GetShopItemList()
    {
        return shopItemList;
    }

    public static void SetShopItemList(List<ShopStatsScript> sItemList)
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

    public static DialogueScript GetDialogueById(int dialogueId)
    {
        return dialogueList.Find(i => i.dialogueId == dialogueId);
    }
}

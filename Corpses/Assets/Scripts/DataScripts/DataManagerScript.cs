using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.AddressableAssets;

// Done by KarLonng

public class DataManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadRefData(Action onLoaded)
    {
        //string filePath = Path.Combine(Application.dataPath, "Data/data.json"); // load data from file path

        //string dataString = File.ReadAllText(filePath); // read data
        ////Debug.Log(dataString);

        //DataReaderScript data = JsonUtility.FromJson<DataReaderScript>(dataString); // create and return data based on data passed in
        //ProcessData(data);

        StartCoroutine(DoLoadRefData("Data/data.json", onLoaded));
    }

    public IEnumerator DoLoadRefData(string path, Action onLoaded)
    {
        bool processing = true; // bool to check if processing has finished yet
        string loadedText = ""; // string to store text loaded

        Addressables.LoadAssetAsync<TextAsset>(path).Completed += (op) =>
        {
            loadedText = op.Result.text; // load assets as text asset

            processing = false; // processing has ended
        };

        while (processing) // while processing is still ongoing
        {
            Debug.Log("Still processing!");
            yield return null; // wait for next frame
        }

        DataReaderScript data = JsonUtility.FromJson<DataReaderScript>(loadedText); // create and return data based on data passed in
        ProcessData(data);

        Debug.Log("Done processing!");

        onLoaded?.Invoke();
    }

    private void ProcessData(DataReaderScript data)
    {
        List<PlayerStatsScript> playerList = new List<PlayerStatsScript>(); // add data to list
        foreach (PlayerReferenceScript playerRef in data.playerList) // for each dataset in list
        {
            PlayerStatsScript player = new PlayerStatsScript(playerRef.playerSprite, playerRef.playerHealth, playerRef.playerSpeed); // pass in values
            playerList.Add(player); // add to list
            //Debug.Log(player.playerHealth);
        }
        DataAccessScript.SetPlayerList(playerList); // set list
        //Debug.Log(DataAccessScript.GetPlayerList().Count);


        List<WeaponStatsScript> weaponList = new List<WeaponStatsScript>(); // add data to list
        foreach (WeaponReferenceScript weaponRef in data.weaponList) // for each dataset in list
        {
            WeaponStatsScript weapon = new WeaponStatsScript(weaponRef.weaponId, weaponRef.weaponName, weaponRef.weaponSprite, weaponRef.attackInterval, weaponRef.attackType, weaponRef.projectileDamage, weaponRef.projectileSpeed, weaponRef.projectileType, weaponRef.despawnTime, weaponRef.startEquipped); // pass in values
            weaponList.Add(weapon); // add to list
            //Debug.Log(weapon.weaponName);

        }
        DataAccessScript.SetWeaponList(weaponList); // set list
        //Debug.Log(DataAccessScript.GetWeaponList().Count);


        List<EnemyStatsScript> enemyList = new List<EnemyStatsScript>(); // add data to list
        foreach (EnemyReferenceScript enemyRef in data.enemyList) // for each dataset in list
        {
            EnemyStatsScript enemy = new EnemyStatsScript(enemyRef.enemyId, enemyRef.enemyName, enemyRef.enemySprite, enemyRef.enemyHealth, enemyRef.enemySpeed, enemyRef.enemyDamage, enemyRef.projectileSpeed, enemyRef.projectileDamage, enemyRef.despawnTime, enemyRef.aggroDistance, enemyRef.attackDistance, enemyRef.retreatDistance, enemyRef.enemyGold, enemyRef.enemyXp, enemyRef.isRanged); // pass in values
            enemyList.Add(enemy); // add to list
        }
        DataAccessScript.SetEnemyList(enemyList); // set list
        //Debug.Log(DataAccessScript.GetEnemyList().Count);


        List<WaveStatsScript> waveList = new List<WaveStatsScript>(); // add data to list
        foreach (WaveReferenceScript waveRef in data.waveList) // for each dataset in list
        {
            WaveStatsScript wave = new WaveStatsScript(waveRef.dungeonId, waveRef.waveNumber, waveRef.enemyId, waveRef.enemyName,waveRef.spawnCount); // pass in values
            waveList.Add(wave); // add to list
            //Debug.Log(wave.dungeonId);
        }
        DataAccessScript.SetWaveList(waveList); // set list
        //Debug.Log(DataAccessScript.GetWaveList().Count);


        List<TimerStatsScript> timerList = new List<TimerStatsScript>(); // add data to list
        foreach (TimerReferenceScript timerRef in data.timerList) // for each dataset in list
        {
            TimerStatsScript timer = new TimerStatsScript(timerRef.spawnIntervalMax, timerRef.spawnIntervalMin, timerRef.spawnIntervalDecrement); // pass in values
            timerList.Add(timer); // add to list
            //Debug.Log(timer.spawnIntervalMax);
        }
        DataAccessScript.SetTimerList(timerList); // set list
        //Debug.Log(DataAccessScript.GetTimerList().Count);


        List<ShopStatsScript> shopItemList = new List<ShopStatsScript>(); // add data to list
        foreach (ShopReferenceScript shopItemRef in data.shopItemList) // for each dataset in list
        {
            ShopStatsScript shopItem = new ShopStatsScript(shopItemRef.shopItemId, shopItemRef.shopItemSprite, shopItemRef.weaponId, shopItemRef.weaponName, shopItemRef.unlockLevel, shopItemRef.goldRequirement); // pass in values
            shopItemList.Add(shopItem); // add to list
        }
        DataAccessScript.SetShopItemList(shopItemList); // set list
        //Debug.Log(DataAccessScript.GetShopItemList().Count);


        List<DialogueScript> dialogueList = new List<DialogueScript>(); // add data to list
         foreach (DialogueReferenceScript dialogueRef in data.dialogueList) // for each dataset in list
         {
             DialogueScript dialogue = new DialogueScript(dialogueRef.dialogueId, dialogueRef.nextDialogueId, dialogueRef.dialogueSetId, dialogueRef.currentSpeaker, dialogueRef.leftImage, dialogueRef.rightImage, dialogueRef.dialogueText); // pass in values
             dialogueList.Add(dialogue); // add to list
         }
         DataAccessScript.SetDialogueList(dialogueList); // set list
         //Debug.Log(DataAccessScript.GetDialogueList().Count);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //LoadRefData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadRefData()
    {
        string filePath = Path.Combine(Application.dataPath, "Data/data.json"); // load data from file path

        string dataString = File.ReadAllText(filePath); // read data
        //Debug.Log(dataString);

        DataReaderScript data = JsonUtility.FromJson<DataReaderScript>(dataString); // create and return data based on data passed in
        ProcessData(data);
    }

    private void ProcessData(DataReaderScript data)
    {
        List<WeaponStatsScript> weaponList = new List<WeaponStatsScript>(); // add data to list
        foreach (WeaponReferenceScript weaponRef in data.weaponList) // for each dataset in list
        {
            WeaponStatsScript weapon = new WeaponStatsScript(weaponRef.weaponId, weaponRef.weaponName, weaponRef.weaponSprite, weaponRef.attackInterval, weaponRef.projectileDamage, weaponRef.projectileSpeed, weaponRef.despawnTime, weaponRef.startEquipped); // pass in values
            weaponList.Add(weapon); // add to list
            //Debug.Log(weapon.weaponName);

        }
        DataAccessScript.SetWeaponList(weaponList); // set list
        //Debug.Log(DataAccessScript.GetWeaponList().Count);


        List<EnemyStatsScript> enemyList = new List<EnemyStatsScript>(); // add data to list
        foreach (EnemyReferenceScript enemyRef in data.enemyList) // for each dataset in list
        {
            EnemyStatsScript enemy = new EnemyStatsScript(enemyRef.enemyId, enemyRef.enemyName, enemyRef.enemySprite, enemyRef.enemyHealth, enemyRef.enemySpeed, enemyRef.enemyDamage, enemyRef.projectileSpeed, enemyRef.projectileDamage, enemyRef.aggroDistance, enemyRef.attackDistance, enemyRef.retreatDistance, enemyRef.enemyGold, enemyRef.enemyXp, enemyRef.isRanged); // pass in values
            enemyList.Add(enemy); // add to list
        }
        DataAccessScript.SetEnemyList(enemyList); // set list
        //Debug.Log(DataAccessScript.GetEnemyList().Count);


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
            DialogueScript dialogue = new DialogueScript(dialogueRef.dialogueId, dialogueRef.displayName, dialogueRef.displaySprite, dialogueRef.dialogueText); // pass in values
            dialogueList.Add(dialogue); // add to list
        }
        DataAccessScript.SetDialogueList(dialogueList); // set list
        //Debug.Log(DataAccessScript.GetDialogueList().Count);

        // (XScript)System.Enum.Parse(typeof(BuffType), xRef.x)
    }
}

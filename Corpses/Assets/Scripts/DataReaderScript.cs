using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataReaderScript
{
    // NAMES HAVE TO BE THE SAME AS EXCEL SHEET NAMES

    public List<PlayerReferenceScript> playerList;
    public List<WeaponReferenceScript> weaponList;
    public List<EnemyReferenceScript> enemyList;
    public List<WaveReferenceScript> waveList;
    public List<TimerReferenceScript> timerList;
    public List<ShopReferenceScript> shopItemList;
    public List<DialogueReferenceScript> dialogueList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

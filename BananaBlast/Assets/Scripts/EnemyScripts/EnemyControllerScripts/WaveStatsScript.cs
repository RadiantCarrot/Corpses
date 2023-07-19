using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class WaveStatsScript
{
    public int dungeonId { get; }
    public int waveNumber { get; }
    public int enemyId { get; }
    public string enemyName { get; }
    public int spawnCount { get; }

    public WaveStatsScript (int dungeonId, int waveNumber, int enemyId, string enemyName, int spawnCount)
    {
        this.dungeonId = dungeonId;
        this.waveNumber = waveNumber;
        this.enemyId = enemyId;
        this.enemyName = enemyName;
        this.spawnCount = spawnCount;
    }
}

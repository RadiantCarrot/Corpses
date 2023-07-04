using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStatsScript
{
    public float spawnIntervalMax { get; }
    public float spawnIntervalMin { get; }
    public float spawnIntervalDecrement { get; }

    public TimerStatsScript(float spawnIntervalMax, float spawnIntervalMin, float spawnIntervalDecrement)
    {
        this.spawnIntervalMax = spawnIntervalMax;
        this.spawnIntervalMin = spawnIntervalMin;
        this.spawnIntervalDecrement = spawnIntervalDecrement;
    }
}

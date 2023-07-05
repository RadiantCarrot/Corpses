using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriterScript : MonoBehaviour
{
    string filename = "";

    // Start is called before the first frame update
    void Start()
    {
        //filename = Application.dataPath + "Data/analytics.csv";
        filename = Application.dataPath + "/Data/analytics.csv";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WriteCSV(string bulletsFired, string enemiesSlain, string highestLevel, string totalPlaytime)
    {
        System.DateTime systemTime = System.DateTime.Now; // get current system time

        TextWriter tw = new StreamWriter(filename, false); // open file. false to overwrite any previous data
        tw.WriteLine("DateTime, BulletsFired, EnemiesSlain, HighestLevel, TotalPlaytime"); // write column headers
        tw.Close(); // close file

        tw = new StreamWriter(filename, true); // reopen file to write data
        tw.WriteLine(systemTime + "," + bulletsFired + "," + enemiesSlain + "," + highestLevel + "," + totalPlaytime); // write data for each parameter in list
        tw.Close(); // close file
    }
}

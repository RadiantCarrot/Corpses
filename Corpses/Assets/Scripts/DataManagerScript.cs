using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadRefData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadRefData()
    {
        string filePath = Path.Combine(Application.dataPath, "Data/TestData.txt"); // load data from file path
        string dataString = File.ReadAllText(filePath); // read data
        Debug.Log(dataString);

        DataReaderScript dataReaderScript = JsonUtility.FromJson <DataReaderScript>(dataString); // create and return data based on data passed in
    }
}

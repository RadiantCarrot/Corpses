using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class GoldCollectionScript : MonoBehaviour
{
    public GameObject goldController;
    public float goldLifetime;

    // Start is called before the first frame update
    void Start()
    {
        goldController = GameObject.Find("GoldController");

        StartCoroutine(Despawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collectInfo)
    {
        if (collectInfo.gameObject.CompareTag("Player")) // if there is player
        {
            goldController.GetComponent<GoldScript>().AddGold(1); // add gold

            Destroy(gameObject); // destroy gold
        }
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(goldLifetime);
        Destroy(gameObject); // destroy gold
    }
}

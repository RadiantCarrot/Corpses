using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatsScript : MonoBehaviour
{
    private string itemName;
    private Sprite itemSprite;
    public int unlockLevel;
    public int goldRequirement;

    // Start is called before the first frame update
    void Start()
    {
        itemName = gameObject.name; // assign name
        itemSprite = gameObject.GetComponent<Sprite>(); // assign sprite
        unlockLevel = 5; // assign unlockLevel
        goldRequirement = 10; // assign goldRequirement
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

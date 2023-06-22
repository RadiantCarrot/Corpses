using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3HealthScript : MonoBehaviour
{
    public int health;

    public XpScript xpScript;
    public int baseXp;
    private int xpBuffer;

    public GameObject gold;
    private float goldRadius = 1f;
    private int dropRate;
    public int goldAmount;

    public Material originalMaterial;
    public Material flashMaterial;
    public SpriteRenderer spriteRenderer;
    public float flashDuration;
    public Coroutine flashRoutine;

    // Start is called before the first frame update
    void Start()
    {
        xpScript = GameObject.Find("XpController").GetComponent<XpScript>(); // assign xp controller

        originalMaterial = spriteRenderer.material; // get the material which the spriterenderer uses
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            GiveXp();
            GiveGold();

            Destroy(gameObject); //die
        }
    }

    public void GiveXp()
    {
        xpScript.AddXp(baseXp); // give player xp
        xpBuffer = (xpScript.playerLevel / 2) * baseXp; // additional xp for scaling
        xpScript.AddXp(xpBuffer); // give player scaling xp
    }

    public void GiveGold()
    {
        dropRate = Random.Range(0, 2); // return random number within range

        if (dropRate == 1) // if gold can spawn
        {
            for (var i = 0; i < goldAmount; i++) // check amount of gold to spawn
            {
                Instantiate(gold, Random.insideUnitSphere * goldRadius + transform.position, transform.rotation); // spawn gold in a radius around self
            }
        }
    }

    void Flash()
    {
        if (flashRoutine != null) // if currently flashing
        {
            StopCoroutine(flashRoutine); // stop flashing, prevents lags/bugs
        }

        flashRoutine = StartCoroutine(FlashRoutine()); // start flashing
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial; // swap original material to flash material

        yield return new WaitForSeconds(flashDuration); // hold sprite material as flash material

        spriteRenderer.material = originalMaterial; // swap flash material back to original material

        flashRoutine = null; // end flashing coroutine
    }
}

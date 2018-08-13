using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //config params
    [SerializeField] AudioClip distorySound;

    [SerializeField] GameObject explosionVFX;

    [SerializeField] int maxHits;

    [SerializeField] Sprite[] damageSprites;


    //cached gameobject reference
    private Level level;
    private GameSession gameSession;

    //state variables
    [SerializeField] int timesHit; //TODO only serialized for debugging

	private void Start()
	{
        timesHit = 0;
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>();
        if (this.tag == "Breakable")
        {
            level.addBlock();
        }
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (this.tag == "Breakable")
        {
            HandleHit();
        }

	}
    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestoryBlock();
        } else if (maxHits - timesHit == 1 && damageSprites.Length >= 1) {
            this.GetComponent<SpriteRenderer>().sprite = damageSprites[damageSprites.Length - 1];
        } else if (maxHits - timesHit == 2 && damageSprites.Length >= 2) {
            this.GetComponent<SpriteRenderer>().sprite = damageSprites[damageSprites.Length - 2];
        }
    }
    private void DestoryBlock()
    {
        AudioSource.PlayClipAtPoint(distorySound, Camera.main.transform.position);
        level.deleteBlock();
        gameSession.addPointPerDestory();
        Debug.Log(this.gameObject.name);
        displayOnDestroy();
        Destroy(gameObject);
    }
    private void displayOnDestroy()
    {
        GameObject fireworkEffect = Instantiate(explosionVFX, this.transform.position, this.transform.rotation);
    }
}
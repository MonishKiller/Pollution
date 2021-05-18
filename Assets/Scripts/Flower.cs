using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject player;
    public GameObject deathEffectPRe;
    private GameObject deatheffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().collectedFlower++;
            DestroyFlower();

        }
    }
    private void DestroyFlower()
    {
        deatheffect = Instantiate(deathEffectPRe, this.transform.position, Quaternion.identity);
        Destroy(deatheffect, 2f);
        Destroy(gameObject);

    }


}

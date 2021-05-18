using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGrenade : MonoBehaviour
{
    public GameObject destroyEffectPrefab;
    public GameObject grenade;
    private int lifetime;
    private int damage = 2;
    // Start is called before the first frame update
    void Start()
    {
        lifetime = 3;
        Invoke("DestroyPrefabs", lifetime);
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // FindObjectOfType<EnemyPatrol>().TakeDamage(damage);
            collision.gameObject.GetComponent<EnemyPatrol>().TakeDamage(damage);
            DestroyPrefabs();

        }
    }
    private void DestroyPrefabs()
    {

        GameObject destroyEffect = Instantiate(destroyEffectPrefab, this.transform.position, Quaternion.identity);
        Destroy(destroyEffect, 2f);
        Destroy(grenade);


    }
}

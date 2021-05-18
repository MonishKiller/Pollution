using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    [SerializeField]
    public float bulletSpeed;
    public GameObject destroyEffectPrefab;


    private Transform player;
    private Vector2 target;
    private int lifetime;

    public int damage;


    private void Start()
    {
        damage = 1;
        lifetime = 3;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        Invoke("DestroyPrefabs", lifetime);
        
    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, bulletSpeed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyPrefabs();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            FindObjectOfType<PlayerHealth>().TakeDamagePlayer(damage);
            DestroyPrefabs();

        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Hitted On platform");
            DestroyPrefabs();

        }
    }
    private void DestroyPrefabs()
    {

        GameObject destroyEffect = Instantiate(destroyEffectPrefab, this.transform.position, Quaternion.identity);
        Destroy(destroyEffect, 2f);
        Destroy(gameObject);


    }
}

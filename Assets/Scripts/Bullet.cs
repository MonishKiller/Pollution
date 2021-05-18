using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed;
    public GameObject destroyEffectPrefab;
    private GameObject destroyEffect;
    private Rigidbody2D rb;
    private bool faceingRight;
    private int damage;


    private void Start()
    {
        damage = 1;
        faceingRight = true;
        rb = GetComponent<Rigidbody2D>();
        faceingRight = FindObjectOfType<PlayerMovement>().facingRight;
        if (faceingRight)
        {
            rb.velocity = transform.right * bulletSpeed;

        }
        else
        {
            rb.velocity = transform.right * -bulletSpeed;


        }
        Invoke("DestroyEffect", 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyPatrol>().TakeDamage(damage);
            DestroyEffect();
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            DestroyEffect();
        }

    }
    private void DestroyEffect()
    {

        destroyEffect = Instantiate(destroyEffectPrefab, this.transform.position, Quaternion.identity);
        Destroy(destroyEffect, 2f);
        Destroy(gameObject);

    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float enemySpeed;
    public float distance;
    public Transform groundDetection;
    private bool movingRight = true;


    public Transform seePos;
    public float  sightRange;


    


    public GameObject player;
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float timeBtwShots;
    private float startTimeBtwShots;



    private bool isPatrolling;




    private bool inRange;
    private bool shoot;
    public float areaRange;
    public LayerMask layerMask ;
    public LayerMask platformMask;



    private int health=5;
    public GameObject destroyEffectEPRefab;
    private GameObject destroyEffect;

    private void Start()
    {

        startTimeBtwShots = timeBtwShots;
        isPatrolling = true;
        shoot = false;


    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyEnemy();
        }



    }

    private void DestroyEnemy()
    {
        destroyEffect = Instantiate(destroyEffectEPRefab, this.transform.position, Quaternion.identity);
        Destroy(destroyEffect, 2f);
        Destroy(gameObject);

    }


    private void Update()
    {


        CheckingForPlayer();
        Patrol();
        if (shoot == true)
        {
            if (startTimeBtwShots <= 0)
            {
                Shoot();
                startTimeBtwShots = timeBtwShots;
            }
            else
            {
                startTimeBtwShots -= Time.deltaTime;
            }
        }
      


    }

    private void Shoot() {

        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("BulletNormal");

    }


    private void CheckingForPlayer() {

        RaycastHit2D playerinfo = Physics2D.Raycast(seePos.position, seePos.right, sightRange,layerMask);
        if (playerinfo.collider == true)
        {
           
            if (playerinfo.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("Hit");
                isPatrolling = false;
                if (inRange = Physics2D.OverlapCircle(this.transform.position, areaRange, layerMask))
                {


                    if (inRange == true)
                    {
                        shoot = true;

                    }


                }
                else
                {
                    shoot = false;
                  //  isPatrolling = true;

                }
            }

        }

    }


    private void Patrol()
    {

        if (isPatrolling)
        {
            transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance,platformMask);
            Debug.Log(groundInfo);
            if (groundInfo.collider == false)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }

            }
           
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, areaRange);
    }

}

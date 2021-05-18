using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greande : MonoBehaviour
{
    public GameObject grenade;
    public int launchforce;
    public float timeBtwShots;
    private float startTimeBtwShot;
    private void Start()
    {
        startTimeBtwShot = timeBtwShots;
    }
    private void Update()
    {


        if (Input.GetMouseButton(0))
        {
            if (startTimeBtwShot <= 0)
            {
                ShootGrenade();
                startTimeBtwShot = timeBtwShots;
            }
            else {
                startTimeBtwShot -= Time.deltaTime;
            }
        }
    }
    void ShootGrenade()
    {
        GameObject greandeIns = Instantiate(grenade, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play("BulletMinion");
        greandeIns.GetComponent<Rigidbody2D>().AddForce(transform.right * launchforce);
    }

   

   





}

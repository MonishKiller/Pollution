using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeWeapon : MonoBehaviour
{
    public float offset;
    public float TimebtwShots;
    public Transform firePos;
    public GameObject bulletPrefab;
    private GameObject bullet;
    public float bulletSpeed;
   
    private float startTimeBtwShots;
    private bool facingRight ;

    private void Start()
    {
        startTimeBtwShots = TimebtwShots;
         facingRight=FindObjectOfType<PlayerMovement>().facingRight;
     }

    // Update is called once per frame
    void Update()
    {
        facingRight = FindObjectOfType<PlayerMovement>().facingRight;


        if (startTimeBtwShots <= 0)
        {
            Fire();
            startTimeBtwShots = TimebtwShots;
        }
        else {
            startTimeBtwShots -= Time.deltaTime;
        }
    }
    private void Fire() {

        if (Input.GetMouseButton(0))
        {
            
             bullet=  Instantiate(bulletPrefab,firePos.position,Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("BulletNormal");
          
        }


    }
  


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   
    public int health;
    public GameObject destroyEffectPlayerP;
    private GameObject destroyEffectPlayer;
    public HealthBar healthbar;
     
   
    private void Start()
    {
        healthbar.SetMaxHealth(health); 
   
    }

    public void TakeDamagePlayer(int damage)
    {
        health -= damage;
        healthbar.SetHealth(health);
        if (health <= 0)
        {
            DeathPlayer();
        }


    }
    private void DeathPlayer()
    {
        destroyEffectPlayer=Instantiate(destroyEffectPlayerP,transform.position,Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("DestroyEnemy");
        Destroy(destroyEffectPlayer, 2f);
        FindObjectOfType<GameManager>().Restart();
        Destroy(gameObject);


    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private bool collided = false;
    private SpriteRenderer platform;
    private Color changeColor;
    private Color black;
    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<SpriteRenderer>();
        changeColor = platform.color;
        black = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (collided==true)
        {
            changeColor -= new Color(0.01f, 0.01f, 0.01f, 0f);
            platform.color = changeColor;
            if (platform.color == black)
            {
                return;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collided = true;
        }
    }
}

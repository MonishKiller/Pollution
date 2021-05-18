using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Vector2 direction;

    public float force;

    public GameObject pointPrefab;
    public GameObject[] points;

    public int numberOfpoints;

    private void Start()
    {
        points = new GameObject[numberOfpoints];

        for (int i = 0; i < numberOfpoints; i++)
        {
            points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity);
        }
    }
    private void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;

        direction = mousepos - bowPos;

        FaceMouse();
        for (int i = 0; i < numberOfpoints; i++)
        {
            points[i].transform.position = pointPosition(i * 0.1f);
        }

    }
    void FaceMouse()
    {
        transform.right = direction;
    }
    Vector2 pointPosition(float t)
    {
        Vector2 currentPointpos = (Vector2)transform.position + (direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t * t);
        return currentPointpos;
    }

    
  
}

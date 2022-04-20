using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformPressure : MonoBehaviour
{
    public TogglePlatform plate;
    public float speed;
    public int startingPoint;
    public Transform[] points;
    private int i;

    

    void Start()
    {
        transform.position = points[startingPoint].position;
    }


    void Update()
    {
        if (plate.ispressed == true)
        {
            i = 1;
        }
        else
        {
            i = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}

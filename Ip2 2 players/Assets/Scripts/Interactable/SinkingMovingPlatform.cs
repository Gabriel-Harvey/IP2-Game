using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingMovingPlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public bool sinking;
    public Transform[] points;
    public Transform sinkPoint;


    [SerializeField]
    private int i;

    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    private void Update()
    {
        if (sinking == false)
        {
            if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
            {
                i++;
                if (i == points.Length)
                {
                    i = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime); 
        }
        else if (sinking == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, sinkPoint.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Evangelos(Clone)")
        {
            collision.transform.SetParent(transform);
            sinking = true;
        }
        else if (collision.gameObject.name == "Angelica(Clone)")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Evangelos(Clone)")
        {
            collision.transform.SetParent(null);
            sinking = false;
        }
        else if (collision.gameObject.name == "Angelica(Clone)")
        {
            collision.transform.SetParent(null);
        }
    }
}

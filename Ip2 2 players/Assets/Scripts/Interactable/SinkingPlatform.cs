using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingPlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public bool sinking;
    public Transform[] points;
    

    [SerializeField]
    private int i;

    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    private void Update()
    {
        if (sinking == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
        else if (sinking == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Evangelos(Clone)")
        {
            collision.transform.SetParent(transform);
            i = 1;
            sinking = true;   
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       if (collision.gameObject.name == "Evangelos(Clone)")
       {
            collision.transform.SetParent(null);
            i = 0;
            sinking = false;
       }
    }



}

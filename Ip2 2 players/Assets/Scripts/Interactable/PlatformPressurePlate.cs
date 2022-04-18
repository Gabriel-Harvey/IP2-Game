using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPressurePlate : MonoBehaviour
{
    [Header("Pressure Plate")]
    public bool ispressed;
    public Animator animator;
    public GameObject LinkedPlatform;

    public void Update()
    {
        if (ispressed == true)
        {
            animator.SetBool("pressed", true);
            LinkedPlatform.GetComponent<MovingPlatform>().enabled = true;
        }
        else
        {
            animator.SetBool("pressed", false);
            LinkedPlatform.GetComponent<MovingPlatform>().enabled = false;

        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
            ispressed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
            ispressed = false;
        }
    }
}

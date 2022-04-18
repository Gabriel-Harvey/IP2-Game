using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Pressure Plate")]
    public bool ispressed;
    public Animator animator;
    public GameObject LinkedDoor;

    public void Update()
    {
        if (ispressed == true)
        {
            animator.SetBool("pressed", true);
            LinkedDoor.SetActive(false);
        }
        else
        {
            animator.SetBool("pressed", false);
            LinkedDoor.SetActive(true);
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

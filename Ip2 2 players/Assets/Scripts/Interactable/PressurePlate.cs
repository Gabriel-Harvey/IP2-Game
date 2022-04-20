using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Pressure Plate")]
    public bool ispressed;
    public Animator animator;
    public GameObject LinkedDoor;
    public float time = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
            //ispressed = true;
            animator.SetBool("pressed", true);
            LinkedDoor.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
            //ispressed = false;
            animator.SetBool("pressed", false);
            StartCoroutine(WaitTime());
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(time);
        LinkedDoor.SetActive(true);
    }



}

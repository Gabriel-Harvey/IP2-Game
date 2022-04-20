using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlatform : MonoBehaviour
{
    [Header("Pressure Plate")]
    public bool ispressed;
    public Animator animator;
    public MovingPlatformPressure platform;
    public float time = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
            animator.SetBool("pressed", true);
            ispressed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
            animator.SetBool("pressed", false);
            StartCoroutine(WaitTime());
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(time);
        ispressed = false;
    }
}

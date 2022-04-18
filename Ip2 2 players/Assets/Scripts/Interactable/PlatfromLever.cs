using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromLever : MonoBehaviour
{
    public Animator animator;
    public bool pulled;
    public GameObject platform;

    Movement movement;

    public void Start()
    {

    }

    private void Update()
    {
        if (pulled == true)
        {
            animator.SetBool("Pulled", true);
            platform.GetComponent<MovingPlatform>().enabled = true;
        }
        else if (pulled == false)
        {
            platform.GetComponent<MovingPlatform>().enabled = false;
        }

    }
}

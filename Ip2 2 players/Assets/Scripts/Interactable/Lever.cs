using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator animator;
    public bool pulled;
    public GameObject linkedDoor;

    Movement movement;

    public void Start()
    {
        
    }

    private void Update()
    {
        if (pulled == true)
        {
            animator.SetBool("Pulled", true);
            linkedDoor.SetActive(false);
        }

    }


  





}

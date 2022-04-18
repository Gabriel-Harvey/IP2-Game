using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionMangement : MonoBehaviour
{
    [Header("Lever Detection")]
    [SerializeField]
    Lever lever;
    public bool colliding;
    public bool isPressed;
    public PlayerInputHandler inputHandler;
    public Movement movement;
    HeartSystem heartSystem;
    public static bool Death;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip button;


    private void Start()
    {
        heartSystem = GameObject.FindGameObjectWithTag("InputManager").GetComponent<HeartSystem>();
    }

    private void FixedUpdate()
    {
        if (colliding == true && isPressed == true)
        {
            lever.pulled = true;
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Death"):
                Debug.Log("Death");
                heartSystem.TakeDamage(1);
                Death = true;
                break;

            case ("Button"):
                audioSource.PlayOneShot(button);
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lever")
        {
            lever = collision.gameObject.GetComponent<Lever>();
            colliding = true;
        }

        if (collision.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene("MenuScreen");
            //inputHandler.NewSpawn();
            //movement.NewScene();
            
        }

        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lever")
        {
            lever = null;
            colliding = false;
        }
    }

   

}

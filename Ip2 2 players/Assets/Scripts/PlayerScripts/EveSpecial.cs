using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveSpecial : MonoBehaviour
{
    public Movement movement;
    public Vector2 breakSpeed;
    public AudioSource audioSource;
    public AudioClip blockBreak;

    [Header("Player Collision")]
    public Collider2D thisCollider;
    public Collider2D otherCollider;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Breakable" && movement._rigidbody.velocity.y <= breakSpeed.y)
        {
            audioSource.PlayOneShot(blockBreak);
            GameObject.Destroy(collision.gameObject);   
            Debug.Log("Break");
        }
    }



    public void Update()
    {
        //Physics2D.IgnoreCollision(thisCollider, otherCollider);

    }
    public void Awake()
    {
        otherCollider = GameObject.Find("Angelica(Clone").GetComponent<CapsuleCollider2D>();
    }
}

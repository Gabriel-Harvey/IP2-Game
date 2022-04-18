using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelicaSpecial : MonoBehaviour
{
    [Header("Player Collision")]
    public Collider2D thisCollider;
    public Collider2D otherCollider;


    void Start()
    {
        otherCollider = GameObject.Find("Evangelos(Clone)").GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Physics2D.IgnoreCollision(thisCollider, otherCollider);

    }

    public void Awake()
    {
        otherCollider = GameObject.Find("Evangelos(Clone)").GetComponent<CapsuleCollider2D>();
    }
}

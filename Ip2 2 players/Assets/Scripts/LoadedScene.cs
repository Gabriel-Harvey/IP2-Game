using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadedScene : MonoBehaviour
{
    public PlayerInputHandler playerInput;
    public Movement movement;

    void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("PlayerInput").GetComponent<PlayerInputHandler>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        playerInput.NewSpawn();
        movement.NewScene();
        Debug.Log("Loaded");
    }


}

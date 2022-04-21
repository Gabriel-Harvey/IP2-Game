using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    Movement player;
    RadialIndicatorClick radial;
    CharacterSwitcher switcher;
    MultipleTargetCamera multipleTarget;
    public List<GameObject> players = new List<GameObject>();
    public GameObject spawn;
    public int indexValue;

    void Start()
    {
        

        spawn = GameObject.FindGameObjectWithTag("SpawnPoint");
        switcher = GameObject.FindGameObjectWithTag("InputManager").GetComponent<CharacterSwitcher>();
        indexValue = switcher.index;

        player = GameObject.Instantiate(players[switcher.index], spawn.transform.position, spawn.transform.rotation).GetComponent<Movement>();
        radial = GameObject.Find("RadialIndicatorUI").GetComponent<RadialIndicatorClick>();
        GameObject.DontDestroyOnLoad(this.gameObject);


    }

    public void Update()
    {
        if (HeartSystem.dead == true)
        {
            Destroy(gameObject);
        }
    }

    public void death()
    {
        GameObject.Instantiate(players[indexValue], spawn.transform.position, spawn.transform.rotation);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (player)
        {
            player.NewMove(context.ReadValue<Vector2>().x);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (player)
        {
            if (context.performed && Mathf.Abs(player._rigidbody.velocity.y) < 0.01f)
            {
                player.LargeJump();
            }

            if (context.canceled && Mathf.Abs(player._rigidbody.velocity.y) > 0f)
            {
                player.SmallJump();
            }
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (player)
        {
            if (context.started)
            {
                player.interact();
                //Debug.Log("Pressed");
            }

            if (context.canceled)
            {
                player.interactCancel();
            }
            Time.timeScale = 1;
            TextTrigger.xPessed = true;
        }
    }
    public void ResetRadial(InputAction.CallbackContext context)
    {
        if (player)
        {
            if (context.started)
            {
                radial.pressed = true;
            }

            if (context.canceled)
            {
                radial.pressed = false;
            }
        }
    }

    public void NewSpawn()
    {
        spawn = GameObject.FindGameObjectWithTag("SpawnPoint");
        Debug.Log("new spawn");
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        Debug.Log("Pressed");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;
    public float jumpForce;
    public float horizontal;
    private bool isFacingRight = true;
    public Animator animator;


    [Header("Other")]
    public Rigidbody2D _rigidbody;
    public PlayerCollisionMangement collisionMangement;
    public HeartSystem heart;
    PlayerInputHandler PlayerInputHandler;

    private void Start()
    {
        PlayerInputHandler = GameObject.FindGameObjectWithTag("PlayerInput").GetComponent<PlayerInputHandler>();
        heart = GameObject.Find("Health").GetComponent<HeartSystem>();
        GameObject.DontDestroyOnLoad(this.gameObject);

    }


    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(horizontal * movementSpeed, _rigidbody.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (!isFacingRight && horizontal > 0f)
        {
            flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            flip();
        }

        if (PlayerCollisionMangement.Death == true && heart.life > 1)
        {

            PlayerCollisionMangement.Death = false;
            GameObject.Find("Evangelos(Clone)").transform.position = PlayerInputHandler.spawn.transform.position;
            GameObject.Find("Angelica(Clone)").transform.position = PlayerInputHandler.spawn.transform.position;
            //SceneManager.LoadScene(0);
        }
        else
        {
            PlayerCollisionMangement.Death = false;
        }


        Debug.Log(_rigidbody.velocity.y);
    }

    public void Update()
    {
        if (HeartSystem.dead == true)
        {
            Destroy(gameObject);
        }
    }

    public void NewScene()
    {
        GameObject.Find("Evangelos(Clone)").transform.position = PlayerInputHandler.spawn.transform.position;
        GameObject.Find("Angelica(Clone)").transform.position = PlayerInputHandler.spawn.transform.position;
        //PlayerCollisionMangement.Death = false;
        Debug.Log("called");
    }

    private void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void LargeJump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
    }

    public void SmallJump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
    }

    public void NewMove(float value)
    {
        horizontal = value;
    }

    public void interact()
    {
        collisionMangement.isPressed = true;

    }

    public void interactCancel()
    {
        collisionMangement.isPressed = false;
    }

    public void ResetPosition()
    {
        GameObject.Find("Evangelos(Clone)").transform.position = PlayerInputHandler.spawn.transform.position;
        GameObject.Find("Angelica(Clone)").transform.position = PlayerInputHandler.spawn.transform.position;
    }
}

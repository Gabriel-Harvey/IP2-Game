using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{

    public GameObject textBox;
    public PlayerCollisionMangement collisionMangement;   
    public static bool xPessed;
    float time = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collisionMangement = collision.gameObject.GetComponent<PlayerCollisionMangement>();
            collisionMangement.textTrigger = this;
            collisionMangement.TextCall();
            textBox.SetActive(true);
            Time.timeScale = 0;
            //Destroy(gameObject);
            //StartCoroutine(WaitTime());
        }

        
    }

    public void Update()
    {
        if(xPessed == true)
        {
            Debug.Log("recived");
            textBox.SetActive(false);
            xPessed = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    public void DestroyText()
    {
        Debug.Log("recived");
        Time.timeScale = 1;
        textBox.SetActive(false);
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(time);
        textBox.SetActive(true);
        Time.timeScale = 0;
    }

}

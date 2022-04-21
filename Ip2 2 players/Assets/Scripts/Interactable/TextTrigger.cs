using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{

    public GameObject textBox;
    public static bool xPessed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textBox.SetActive(true);
            Time.timeScale = 0;
            //Destroy(gameObject);
        }

        
    }

    public void Update()
    {
        if(xPessed == true)
        {
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

}

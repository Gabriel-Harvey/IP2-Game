using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void Level1Button()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Level2Button()
    {
        SceneManager.LoadScene("Level2");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void Start()
    {
        if (GameObject.Find("Main Camera Track"))
        {
            //Debug.Log("Found");
            GameObject.Find("Main Camera").GetComponent <AudioListener>().enabled = false;
        }
        else 
        {
            //Debug.Log("Not found");
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;

        }
    }

    public void Update()
    {
        /*if (GameObject.Find("Main Camera Track"))
        {
            //Debug.Log("Found");
            GameObject.Find("Main Camera").GetComponent <AudioListener>().enabled = false;
        }
        else 
        {
            Debug.Log("Not found");
            //GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;

        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    //public static HeartSystem Instance;
    public GameObject[] hearts;
    public int life = 3;
    public static bool dead;
    //public static bool Death;

    private void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
       
    }

    void Update()
    {
        if (dead == true)
        {
            SceneManager.LoadScene("Death Screen");
        }
    }

    public void TakeDamage(int d)
    {

        if (life >= 1)
        {
            life -= d;
            Destroy(hearts[life].gameObject);
            //Death = true;
            if (life < 1)
            {
                dead = true;
            }
        }
    }
}

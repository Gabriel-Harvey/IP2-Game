using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTest : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetButtonDown("P"))
        {
            Time.timeScale = 0;
        }
    }
}

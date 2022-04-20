using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RadialIndicatorClick : MonoBehaviour
{
    [SerializeField] private float indicatorTimer = 1.0f;
    [SerializeField] private float maxIndicatorTimer = 1.0f;

    [SerializeField] private Image radialIndicatorUI = null;

    [SerializeField] private KeyCode selectKey = KeyCode.Mouse0;

    [SerializeField] private UnityEvent myEvent = null;

    private bool shouldUpdate = false;
    public bool pressed;
    public Movement player;

    

    private void Update()
    { 
        if (pressed == true)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
            shouldUpdate = false;
            indicatorTimer -= Time.deltaTime;
            radialIndicatorUI.enabled = true;
            radialIndicatorUI.fillAmount = indicatorTimer;

            if (indicatorTimer <= 0)
            {
                //Debug.Log("Reset");
                player.ResetPosition();
                indicatorTimer = maxIndicatorTimer;
                radialIndicatorUI.fillAmount = maxIndicatorTimer;
                radialIndicatorUI.enabled = false;
                myEvent.Invoke();
            }
        }
        else
        {
            if (shouldUpdate)
            {
                indicatorTimer += Time.deltaTime;
                radialIndicatorUI.fillAmount = indicatorTimer;

                if (indicatorTimer >= maxIndicatorTimer)
                {
                    indicatorTimer = maxIndicatorTimer;
                    radialIndicatorUI.fillAmount = maxIndicatorTimer;
                    radialIndicatorUI.enabled = false;
                    shouldUpdate = false;
                }
            }

            
        }

        if(pressed == true)
        {
            shouldUpdate = true;
        }

        if (indicatorTimer == 0.99)
        {
            SceneManager.LoadScene("Scenes/" + SceneManager.GetActiveScene().name);
        }
    }
}

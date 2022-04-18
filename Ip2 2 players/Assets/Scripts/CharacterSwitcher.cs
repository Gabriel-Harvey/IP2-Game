using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    public static CharacterSwitcher Instance;
    public int index = 0;
    public void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        if (HeartSystem.dead == true)
        {
            Destroy(gameObject);
        }
    }

    public void SwitchCharacterSpawn(PlayerInput input)
    {

        StartCoroutine(WaitTimerCourotine());      
    }

    IEnumerator WaitTimerCourotine()
    {
        yield return new WaitForSeconds(0.1f);
        index = 1;
    }

}

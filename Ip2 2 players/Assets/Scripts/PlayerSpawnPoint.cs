using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject[] LevelSpawns;
    public int levelNo;

    private void Update()
    {
        switch (levelNo)
        {
            case (0):
                gameObject.transform.position = LevelSpawns[levelNo].transform.position;
                Debug.Log("Level 1");
                break;

            case (1):
                gameObject.transform.position = LevelSpawns[levelNo].transform.position;
                break;

            case (2):
                gameObject.transform.position = LevelSpawns[levelNo].transform.position;
                break;
        }
    }
}

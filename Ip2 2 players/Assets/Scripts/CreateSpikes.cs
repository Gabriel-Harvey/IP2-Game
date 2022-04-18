using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpikes : MonoBehaviour
{
    public GameObject spikePrefab;
    public float respawnTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spikeWave());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(spikePrefab) as GameObject;
    }
    IEnumerator spikeWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public int waveNumber = 0;
    public int waveMultiplier = 2;
    public static int enemiesLeft = 0;

    private bool waveOngoing = false;
    private int enemyCap = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press ENTER to start enemy spawner wave test");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (waveOngoing == false)
            {
                enemyCap = waveNumber * waveMultiplier;
                enemiesLeft = enemyCap;
                waveOngoing = true;
                waveNumber += 1;

                int i = 0;
                for(i = 0; i < enemyCap; i ++)
                {
                    Instantiate(enemyPrefab, new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f)), Quaternion.identity);
                }
            }
        }

        if (waveOngoing == true && enemiesLeft <= 0)
        {
            waveOngoing = false;
        }
    }
}

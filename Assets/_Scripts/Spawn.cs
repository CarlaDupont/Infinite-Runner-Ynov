using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private int offSet = 100;
    SpawnerManager spawnerManager;

    private void Start()
    {
        spawnerManager = GameObject.Find("SpawnerManager").GetComponent<SpawnerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Instantie la plateforme
            GameObject newPlatform = Instantiate(spawnerManager.platform, new Vector3(0, 0, transform.position.z + offSet), Quaternion.identity);
            int[] possibleX = { -6, 0, 6 };
            for (int i = -45; i <= 45; i += 15)
            {
                int randomIndex = Random.Range(0, 2);
                int randomObstacle = Random.Range(0, 2);
                Instantiate(spawnerManager.obstacles[randomObstacle], new Vector3(possibleX[randomIndex], spawnerManager.platform.transform.position.y + spawnerManager.obstacles[randomIndex].transform.position.y, newPlatform.transform.position.z + i), transform.rotation);
            }

            // Détruit la plateforme après 5sec
            Destroy(newPlatform, 15f);
        }
    }
}


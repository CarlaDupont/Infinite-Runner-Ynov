using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager GM;
    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            GM.deadScreen.SetActive(true);
            Debug.Log("Perdu");
            Time.timeScale = 0f;
        }
    }
}

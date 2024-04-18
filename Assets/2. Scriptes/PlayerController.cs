using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public Manager manager;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
    }
    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gm = FindAnyObjectByType<GameManager>();
        gm.EndGame();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {

            SceneManager.LoadScene(2);

        }
    }
}
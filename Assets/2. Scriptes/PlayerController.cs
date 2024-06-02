using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int endingScene;

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

            SceneManager.LoadScene(endingScene);

        }
    }
}
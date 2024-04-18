using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Videotime : MonoBehaviour
{
    float timer;
    public int waitingTime;
    void Start()
    {
        timer = 0f;
        waitingTime = 18;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            SceneManager.LoadScene(2);
            timer = 0;
        }
    }
}

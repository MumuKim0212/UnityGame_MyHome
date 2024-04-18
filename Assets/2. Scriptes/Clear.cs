using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    public GameObject quitButton;
    void Start()
    {

        StartCoroutine(QuitGame());

        IEnumerator QuitGame()
        {
            yield return new WaitForSeconds(9f);
            quitButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

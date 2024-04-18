using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void NextScene(int sceneID)
    {
        StartCoroutine(LoadScene(sceneID));
    }
    IEnumerator LoadScene(int sceneID)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneID);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text distanceText;
    public Text recordText;
    Transform playerTransform;

    float surviveDis;
    bool isGameover;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        surviveDis = 0;
        isGameover = false;
    }

    public void EndGame()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGameover = true;
        // 게임오버 텍스트 게임 오브젝트 활성화
        gameoverText.SetActive(true);

        // 저장된 최고기록 가져오기
        float bestDistance = PlayerPrefs.GetFloat("BestDistance");

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviveDis > bestDistance)
        {
            bestDistance = surviveDis;
            PlayerPrefs.SetFloat("BestDistance", bestDistance);
        }
        recordText.text = "Best Distance : " + (int)bestDistance;
    }

    void Update()
    {
        if (!isGameover)
        {
            surviveDis = playerTransform.position.z + 20;
            distanceText.text = "Distance : " + (int)surviveDis;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

    }
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GoNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

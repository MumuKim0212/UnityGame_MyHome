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
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ Ȱ��ȭ
        gameoverText.SetActive(true);

        // ����� �ְ��� ��������
        float bestDistance = PlayerPrefs.GetFloat("BestDistance");

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
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

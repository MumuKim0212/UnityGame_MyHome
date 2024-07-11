using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuPanel;

    public void OpenMenu()
    {
        menuPanel.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        menuPanel.gameObject.SetActive(false);
    }
}
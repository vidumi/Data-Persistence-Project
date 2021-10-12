using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUi : MonoBehaviour
{

    public GameObject inputField;
    public Text bestScorePlayer;
    public GameObject alertPanel;
    private void Start()
    {
        bestScorePlayer.text = "Best Score: " + GameManager.Instance.bestPlayerName + " : " + GameManager.Instance.bestScore;
    }

    public void StartNew()
    {
        if (inputField.GetComponent<Text>().text == "")
        {
            alertPanel.gameObject.SetActive(true);
            return;
        }

        StoreCurrentName();
        GameManager.Instance.SavePlayerData();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        GameManager.Instance.SavePlayerData();

    }

    public void StoreCurrentName()
    {
        GameManager.Instance.currentPlayerName = inputField.GetComponent<Text>().text;
    }

}
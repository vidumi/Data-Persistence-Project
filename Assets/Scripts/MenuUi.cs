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
    private void Start()
    {
        bestScorePlayer.text = "Best Score: " + GameManager.Instance.playerName + " : " + GameManager.Instance.bestScore;
    }

    public void StartNew()
    {
        if (inputField.GetComponent<Text>().text == "")
        {
            return;
        }

        StoreName();
        GameManager.Instance.SavePlayerData();
        SceneManager.LoadScene(1);
        Debug.Log(inputField);

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


    public void StoreName()
    {
        GameManager.Instance.playerName = inputField.GetComponent<Text>().text;
    }

}
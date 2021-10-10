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
    public Text lastPlayer;
    private void Start()
    {
        lastPlayer.text = GameManager.Instance.playerName;
    }

    public void StartNew()
    {
        StoreName();
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


    public void StoreName()
    {
        GameManager.Instance.playerName = inputField.GetComponent<Text>().text;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;

    public Text bestScorePlayer; //ADD


    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    private int intBestScore = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        BestPlayer(); //ADD
    }

    private void BestPlayer() //ADD
    {      
       if (GameManager.Instance.bestScore == "")
        {
            intBestScore = 0;
        }
        else
        {
        intBestScore = System.Convert.ToInt32(GameManager.Instance.bestScore);
        bestScorePlayer.text = "Best Score: " + GameManager.Instance.bestPlayerName + " : " + GameManager.Instance.bestScore;  //ADD
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);

            }

        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

        SaveBestPlayer(); //ADD
    }

    private void SaveBestPlayer() //ADD
    {
        if (m_Points > intBestScore)
        {
            GameManager.Instance.bestScore = m_Points.ToString();
            GameManager.Instance.bestPlayerName = GameManager.Instance.currentPlayerName;
            GameManager.Instance.SavePlayerData();
        }
    }

    public void LoadMenu() // ADD
    {
        SceneManager.LoadScene(0);
        SaveBestPlayer();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_scoreText = null;
    [SerializeField] GameObject m_pausePanel = null;
    [SerializeField] GameObject m_gameOverPanel = null;
    [SerializeField] TextMeshProUGUI m_highScoreText = null;

    Player player = null;

    private int m_score = 0;
    private float m_timer = 0.1f;

    private void Start()
    {
        Time.timeScale = 1.0f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0.0f)
        {
            m_score++;
            m_timer += 0.1f;
        }
        m_scoreText.text = "Score: " + m_score.ToString("D5");
        if (player.lose)
        {
            GameOver();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = (Time.timeScale == 0.0f) ? 1.0f : 0.0f;
        m_pausePanel.SetActive(!m_pausePanel.activeSelf);
		player.GetComponent<Player>().enabled = !player.GetComponent<Player>().enabled;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("PlatformTest");
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        m_gameOverPanel.SetActive(true);
        if (m_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", m_score);
            m_highScoreText.text = "New High Score!\n" + m_score;
        }
        else
        {
            m_highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
    }

    public void QuitGame()
    {
        //#if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPlaying = false;
        //#else
        //        Application.Quit();
        //#endif

        SceneManager.LoadScene("Main Menu");
    }
}

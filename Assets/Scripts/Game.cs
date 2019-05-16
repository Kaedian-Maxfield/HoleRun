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

    private int m_score = 0;
    private float m_timer = 0.1f;

    private void Start()
    {
        Time.timeScale = 1.0f;
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
    }

    public void PauseGame()
    {
        Time.timeScale = (Time.timeScale == 0.0f) ? 1.0f : 0.0f;
        m_pausePanel.SetActive(!m_pausePanel.activeSelf);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("PlatformTest");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

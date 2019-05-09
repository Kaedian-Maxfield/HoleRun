using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_scoreText = null;
    [SerializeField] GameObject m_fallArea = null;
    [SerializeField] GameObject m_player = null;

    int m_score;
    float m_timer = 0.5f;
    float m_timerReset = 0.5f;
    
    void Update()
    {
        m_scoreText.text = m_score.ToString("D5");
        m_timer -= Time.deltaTime;
        if(m_timer <= 0.0f)
        {
            m_timer = m_timerReset;
            m_score += 1;
        }
        if (m_fallArea.GetComponent<LoseArea>().playerFallen)
        {
            Time.timeScale = 0.0f;
            m_player.GetComponent<Player>().enabled = false;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxTrigger : MonoBehaviour
{
    public AudioSource m_audioSource;
    public AudioClip m_gameOver;

    public void GameOver()
    {
        m_audioSource.PlayOneShot(m_gameOver);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameOver();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject m_howToPlay = null;
    [SerializeField] float m_rotSpeed = 0.125f;

    private void Update()
    {
        Camera.main.transform.Rotate(Vector3.up * m_rotSpeed);
    }

    public void Play()
    {
        SceneManager.LoadScene("PlatformTest");
    }

    public void InfoMenu()
    {
        m_howToPlay.SetActive(!m_howToPlay.activeSelf);
    }
}
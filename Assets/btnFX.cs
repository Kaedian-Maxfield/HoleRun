using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioSource m_audioSource;
    public AudioClip m_hoverFx;
    public AudioClip m_clickFx;

    public void HoverSound()
    {
        m_audioSource.PlayOneShot(m_hoverFx);
    }
    public void ClickSound()
    {
        m_audioSource.PlayOneShot(m_clickFx);
    }
}

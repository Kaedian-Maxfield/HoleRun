using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseArea : MonoBehaviour
{
    public bool playerFallen = false;

    [SerializeField] GameObject m_player = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerFallen = true;
            m_player.GetComponent<Player>().enabled = false;
            m_player.GetComponent<Rigidbody>().isKinematic = true;
            Time.timeScale = 0.0f;
        }
    }
}

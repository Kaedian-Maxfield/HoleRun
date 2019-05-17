using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] GameObject m_player = null;

    public bool isInside { get; set; }

    // Update is called once per frame
    void Update()
    {
        if(isInside)
        {
            Vector3 direction = m_player.transform.position - new Vector3(transform.position.x, 0.0f, 0.0f);
            float distance = m_player.transform.position.magnitude;

            if(m_player.transform.position.x < this.transform.position.x)
            {
                m_player.transform.position -= direction.normalized * ( (2/distance * 10) * Time.deltaTime);
            }
            else
            {
                m_player.transform.position -= direction.normalized * ( (2/distance * 10) * Time.deltaTime);
                //m_player.transform.position += new Vector3(this.transform.position.normalized.x * (2 * Time.deltaTime), 0.0f, 0.0f);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { isInside = true; Debug.Log("Player Entered"); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") { isInside = false; Debug.Log("Player Exited"); }
    }
}

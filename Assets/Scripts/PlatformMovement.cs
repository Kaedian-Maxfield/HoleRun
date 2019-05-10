using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] Rigidbody m_rb = null;
    [SerializeField] float m_speed = 1.0f;

    bool barrier = false;
    float m_timer = 1.0f;
    float m_timerReset = 1.0f;

    void Update()
    {
        if (!barrier)
        {
            if(transform.localScale.x <= 0.0005f)
            {
                transform.position = transform.position;
            }
            else
            {
                transform.position -= new Vector3(m_speed, 0.0f, 0.0f) * Time.deltaTime;
            }
            if(m_timer <= 0.93f)
            {
                float randY = Random.Range(-3.5f, 4.0f);
                transform.position = new Vector3(20.0f, randY, transform.position.z);
                transform.localScale = new Vector3(2.0f, 0.5f, 1.0f);
                m_timer = m_timerReset;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barrier")
        {
            barrier = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Barrier")
        {
            transform.position -= new Vector3(m_speed / 2.0f, 0.0f, 0.0f) * Time.deltaTime;
            transform.localScale -= new Vector3(0.5f, 0.0f, 0.0f);
            m_timer -= Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Barrier")
        {
            barrier = false;
        }
    }
}

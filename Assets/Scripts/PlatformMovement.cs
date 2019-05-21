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
    float m_speedTimer = 10.0f;
    float m_speedResetTimer = 10.0f;
    bool rotates = false;
    float Rando;

    private void Start()
    {
        Rando = Random.Range(0.0f, 2.0f);
        if(Rando <= 0.5f)
        {
            rotates = true;
        }
    }

    void Update()
    {
        float dt = Time.deltaTime;
        m_speedTimer -= dt;
        if(m_speedTimer <= 0.0f)
        {
            m_speedTimer = m_speedResetTimer;
            m_speed += 0.25f;
        }

        if (!barrier)
        {
            if (transform.localScale.x <= 0.0005f)
            {
                transform.position = transform.position;
            }
            else
            {
                transform.position -= new Vector3(m_speed, 0.0f, 0.0f) * dt;
                if (rotates && Time.timeScale != 0.0f)
                {
                    transform.RotateAround(transform.position, new Vector3(0.0f, 0.0f, 1.0f), 0.1f);
                }
            }
        }
            if(m_timer <= 0.93f)
            {
                float randY = Random.Range(-3.5f, 4.0f);
                transform.position = new Vector3(20.0f, randY, transform.position.z);
                transform.localScale = new Vector3(2.0f, 0.5f, 1.0f);
                transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                m_timer = m_timerReset;
                Rando = (int)Random.Range(0, 4);
                if (Rando <= 0.5f)
                {
                    rotates = true;
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
        float dt = Time.deltaTime;
        if (other.tag == "Barrier")
        {
            transform.position -= new Vector3(m_speed / 2.0f, 0.0f, 0.0f) * dt;
            transform.localScale -= new Vector3(0.5f, 0.0f, 0.0f);
            m_timer -= dt;
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

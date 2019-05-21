using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMoevement : MonoBehaviour
{
    [SerializeField] float m_speed = 1.0f;

    bool barrier = false;
    float m_timer = 1.0f;
    float m_timerReset = 1.0f;

    void Update()
    {
        float dt = Time.deltaTime;
        if (!barrier)
        {
            if (transform.localScale.x <= 0.0005f)
            {
                transform.position = transform.position;
            }
            else
            {
                transform.position -= new Vector3(m_speed, 0.0f, 0.0f) * dt;               
            }
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barrier")
        {
            float randY = Random.Range(-3.5f, 4.0f);
            transform.position = new Vector3(20.0f, randY, transform.position.z);
            transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}

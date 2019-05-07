using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject m_player = null;
    [SerializeField] Rigidbody m_rb = null;
    [SerializeField] float m_speed = 1.0f;
    [SerializeField] float m_jumpLength = 1.0f;
    bool canJump = true;
    float timer = 0.0f;
    float jumpForce = 5.0f;

    private void Start()
    {
        m_speed /= 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            m_player.transform.Translate(Vector3.right * m_speed, Space.Self);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            m_player.transform.Translate(Vector3.left * m_speed, Space.Self);
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && canJump && timer > 0.0f)
        {
            m_rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && canJump && timer > 0.0f)
        { 
            m_rb.AddForce(Vector3.up * jumpForce);
            timer -= Time.deltaTime;
        }
        if (timer < 0.0f || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            m_rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        canJump = true;
        timer = m_jumpLength;
    }
}

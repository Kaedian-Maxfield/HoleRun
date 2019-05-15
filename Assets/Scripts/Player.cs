using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject m_player = null;
    [SerializeField] Animator m_animator = null;
    [SerializeField] float m_speed = 15.0f;
    [SerializeField] float m_jumpLength = 1.0f;
    [SerializeField] float jumpForce = 5.0f;
    Rigidbody m_rb = null;
    bool canJump = true;
    bool rightTopCollide = false;
    bool rightMiddleCollide = false;
    bool rightBottomCollide = false;
    bool leftTopCollide = false;
    bool leftMiddleCollide = false;
    bool leftBottomCollide = false;
    float timer = 0.0f;
    float distance = 0.6f;
    Vector3 top = Vector3.zero;
    Vector3 bottom = Vector3.zero;
    RaycastHit hit;
    Ray ray;

    private void Start()
    {
        m_speed /= 100;
        gameObject.AddComponent<Rigidbody>();
        m_rb = gameObject.GetComponent<Rigidbody>();
        m_rb.constraints = RigidbodyConstraints.FreezeRotation;
        timer = m_jumpLength;
        
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        top = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
        bottom = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z);
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rightTopCollide = Physics.Raycast(top, gameObject.transform.TransformDirection(Vector3.right), out hit, distance);
            rightMiddleCollide = Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.right), out hit, distance);
            rightBottomCollide = Physics.Raycast(bottom, gameObject.transform.TransformDirection(Vector3.right), out hit, distance);
            if (!rightTopCollide && !rightMiddleCollide && !rightBottomCollide)
            {
                gameObject.transform.Translate(Vector3.right * m_speed, Space.Self);
                if (m_player.transform.rotation.eulerAngles.y == 270.0f)
                {
                    Debug.Log("Look R");
                    m_player.transform.Rotate(0.0f, -180.0f, 0.0f);
                }
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            leftTopCollide = Physics.Raycast(top, gameObject.transform.TransformDirection(Vector3.left), out hit, distance);
            leftMiddleCollide = Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.left), out hit, distance);
            leftBottomCollide = Physics.Raycast(bottom, gameObject.transform.TransformDirection(Vector3.left), out hit, distance);
            if (!leftTopCollide && !leftMiddleCollide && !leftBottomCollide)
            {
                gameObject.transform.Translate(Vector3.left * m_speed, Space.Self);
                if(m_player.transform.rotation.eulerAngles.y == 90.0f)
                {
                    Debug.Log("Look L");
                    m_player.transform.Rotate(0.0f, 180.0f, 0.0f);
                }
            }
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && canJump && timer > 0.0f)
        {
            Debug.Log("Jump");
            m_rb.AddForce(Vector3.up * jumpForce);
            timer -= Time.deltaTime;
        }
        if (timer < 0.0f || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            canJump = false;
        }
        if (Physics.Raycast(bottom, gameObject.transform.TransformDirection(Vector3.down), out hit, distance))
        {
            Debug.Log("onPlatform");
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && canJump && timer > 0.0f)
            {
                Debug.Log("jump");
                m_rb.AddForce(Vector3.up * (jumpForce + (m_rb.velocity.y * -1.0f)), ForceMode.Impulse);
            }
            canJump = true;
            timer = m_jumpLength;
        }
        m_animator.SetFloat("Speed", m_rb.velocity.x);

        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Fall") && timer > 0.0f && m_rb.velocity.y >= -0.1f)
        {
            m_animator.SetBool("Fall", false);
            m_animator.SetTrigger("Land");
        } 
        else
        {
            if (m_rb.velocity.y < 0.0f)
            {
                m_animator.SetBool("Fall", true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Physics.Raycast(bottom, gameObject.transform.TransformDirection(Vector3.down), out hit, distance))
        {
            Debug.Log("collide");
            canJump = true;
            timer = m_jumpLength;
        }
    }
}

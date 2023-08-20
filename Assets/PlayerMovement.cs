using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40;

    float horizontalMove = 0;
    bool jump = false;
    public bool crouch = false;
    Animator m_animator;
    private void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
            //m_animator.Play("Jumping");
            m_animator.SetBool("isJumping", true);
            m_animator.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            //m_animator.Play("Running");
            m_animator.SetBool("isRunning", true);
        }
        else
        {
            //m_animator.Play("Stationary");
            m_animator.SetBool("isJumping", false);
            m_animator.SetBool("isRunning", false);
        }


        if (transform.position.y < -10)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;

    }
}

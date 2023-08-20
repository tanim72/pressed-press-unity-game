
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    float horizontalMove = 0f;
    [SerializeField] float runSpeed = 10;
    Animator flint;
    public float m_JumpForce = 20f;
    private Rigidbody2D m_Rigidbody2D;
    bool jump = true;
    [SerializeField] public float ySpeed = 10f;
    public float nSpeed;

    SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        nSpeed = 7f;
        flint = gameObject.GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * runSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * runSpeed * Time.deltaTime;
        }
        

    }
    public void Jump()
    {
        if (jump)
        {
            //transform.position += Vector3.up * m_JumpForce * Time.deltaTime;
            m_Rigidbody2D.AddForce(this.gameObject.transform.up*m_JumpForce);
            jump = false;
        }
    }
    public void OnCollisionStay2D(Collision2D collidingObject)
    {
        if (collidingObject.gameObject.name == "Platform")
        {
            jump = true;
        }
    }
}

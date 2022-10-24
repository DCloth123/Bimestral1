using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer2 : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float turnSpeed;
    public float moveSpeed;
    public float speed;

    public bool canJump;
    public bool canShift;
    public float jumpForce;

    public Transform _InitialPos;

    public bool IsInGround;

    [SerializeField] GameManager gameManager;

    public bool OpenDoor;
    public Animator anim;

    [SerializeField] Animator UpAnim;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger") && gameManager.lifes > 0)
        {
            transform.position = _InitialPos.position;
            gameManager.lifes -= 1;
        }

        if (other.CompareTag("Ground")) IsInGround = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground")) IsInGround = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground")) IsInGround = false;
    }

    public void Move()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        anim.SetFloat("Running", moveVertical);

        if (moveVertical != 0)
        {
            anim.SetBool("Isidle", false);
        }
        else anim.SetBool("Isidle", true);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetFloat("ShiftWalfing", moveVertical);
        }

        transform.Translate(0, 0, moveVertical * speed * Time.deltaTime);
        transform.Rotate(0, moveHorizontal, 0 * turnSpeed * Time.deltaTime);

        canJump = true;
        canShift = true;

        if (canJump && IsInGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                anim.SetFloat("Jump", jumpForce);
            }
        }

        if (canShift)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetBool("Shifting", true);
            }
            else
            {
                anim.SetBool("Shifting", false);
            }
        }
    }
}
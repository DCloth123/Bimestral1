using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float turnSpeed;
    public float moveSpeed;
    public float speed;

    public bool canJump;
    public bool canShift;
    public float jumpForce;

    public Transform _InitialPos;

    public GameObject[] plataforms;
    public bool IsInGround;

    [SerializeField] GameManager gameManager;


    public bool IsKey;
    public bool OpenDoor;
    public Animator anim;

    [SerializeField] Animator UpAnim;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
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

        if (other.CompareTag("PowerUp"))
        {
            canJump = true;

            plataforms[0].GetComponent<Rigidbody>().useGravity = true;
            plataforms[0].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            Destroy(other.gameObject);
        }
        if (other.CompareTag("PowerUp2"))
        {
            canShift = true;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Key"))
        {
            gameManager.IsKey = true;
            Destroy(other.gameObject);

            plataforms[1].GetComponent<Rigidbody>().useGravity = true;
            plataforms[1].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            plataforms[2].GetComponent<Rigidbody>().useGravity = true;
            plataforms[2].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            plataforms[3].GetComponent<Rigidbody>().useGravity = true;
            plataforms[3].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            plataforms[4].GetComponent<Rigidbody>().useGravity = true;
            plataforms[4].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Destroy(other.gameObject);

            UpAnim.SetBool("Up", true);
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

        if(moveVertical != 0)
        {
            anim.SetBool("Isidle", false);
        }
        else anim.SetBool("Isidle", true);
        
        anim.SetFloat("Turning", moveHorizontal);

        if(moveHorizontal != 0)
        {
            anim.SetBool("Isidle", false);
        }
        else anim.SetBool("Isidle", true);

        transform.Translate(0, 0, moveVertical * speed * Time.deltaTime);
        transform.Rotate(0, moveHorizontal, 0 * turnSpeed * Time.deltaTime);

        if (canJump && IsInGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                anim.SetFloat("Jumping", jumpForce);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            canShift = !canShift;
            anim.SetFloat("ShiftWalk", moveVertical);
        }
        if (canShift == true)
        {
            anim.SetBool("Shifting", true);
        }
        if (canShift == false)
        {
            anim.SetBool("Shifting", false);
        }
    }
}
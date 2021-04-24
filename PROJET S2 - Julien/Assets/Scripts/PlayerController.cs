using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController cc;

    //Movement Variables
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintFactor = 1.75f;

    //Ground Checking Variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    //Gravity vector
    Vector3 velocity;

    //Mouse Look
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Transform cameraHolder;
    private float verticalRotation = 0f;

    PhotonView PV;


    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        if(!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(cc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
            return;
        Move();
        Look();
    }


    //player movement


    void Move()
    {
        //Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Movement Inputs and actions
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift))
            cc.Move(move.normalized * speed * sprintFactor * Time.deltaTime);
        else
            cc.Move(move.normalized * speed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //Gravity
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }



    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        cameraHolder.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

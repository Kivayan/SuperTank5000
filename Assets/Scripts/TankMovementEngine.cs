using UnityEngine;

public class TankMovementEngine : MonoBehaviour
{
    private CharacterController controller;
    public float turnSpeed;
    private bool MoveFWD = true;

    public float speed;
    private Vector3 moveDirection = Vector3.forward;


    // Use this for initialization
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        DebugInfo();
        Movement();
        MovementDirection();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0) * turnSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0) * turnSpeed);
        }
    }

    private void MovementDirection()
    {
        if (Input.GetKeyDown(KeyCode.W))
            MoveFWD = true;

        if (Input.GetKeyDown(KeyCode.S))
            MoveFWD = false;


    }

    private void MoveForward()
    {
        //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //moveDirection = transform.TransformDirection(moveDirection);
        //moveDirection *= speed;

        switch (MoveFWD)
        {
            case true:
                moveDirection = transform.TransformDirection(Vector3.forward);
                break;

            case false:
                moveDirection = transform.TransformDirection(Vector3.back);
                break;
        }
        controller.Move(moveDirection * speed);
    }

   private void DebugInfo()
    {
        DebugPanel.Log("MoveFWD", MoveFWD);
    }
}
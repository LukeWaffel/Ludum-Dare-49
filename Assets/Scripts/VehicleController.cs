using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private new Rigidbody2D rigidbody;
    [SerializeField]
    private WheelJoint2D frontWheel;
    [SerializeField]
    private WheelJoint2D backWheel;

    private JointMotor2D frontMotor;
    private JointMotor2D backMotor;

    [Header("Config")]

    [SerializeField]
    private float speed = 1000f;
    [SerializeField]
    private float leanPower = 750f;

    [SerializeField]
    private Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        frontMotor = frontWheel.motor;
        backMotor = backWheel.motor;
    }

    // Update is called once per frame
    void Update()
    {
        //Driving
        frontMotor.motorSpeed = speed * -input.y;
        backMotor.motorSpeed = speed * -input.y;

        frontWheel.motor = frontMotor;
        backWheel.motor = backMotor;

        backWheel.useMotor = input.y != 0;
        frontWheel.useMotor = input.y != 0;

        //Leaning
        rigidbody.angularVelocity += leanPower * -input.x * Time.deltaTime;
    }

    //Called by PlayerInput
    public void MovementEvent(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        this.input = input;
    }
}
using UnityEngine;
using UnityEngine.InputSystem;
using ExpPlus.Phariables;

public class VehicleController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private new Rigidbody2D rigidbody;
    [SerializeField]
    private GameObject frontWheelGameObject;
    [SerializeField]
    private WheelJoint2D frontWheelJoint;
    [SerializeField]
    private GameObject backWheelGameObject;
    [SerializeField]
    private WheelJoint2D backWheelJoint;

    private JointMotor2D frontMotor;
    private JointMotor2D backMotor;

    [Header("Config")]

    [SerializeField]
    private Transform centerOfMass;
    [SerializeField]
    private float speed = 1000f;
    [SerializeField]
    private float leanPower = 1000f;
    [SerializeField]
    private float wheelRadius = 0.4f;
    [SerializeField]
    private LayerMask wheelMask;

    [Header("Status")]
    [SerializeField]
    private BoolRepherence  grounded;
    [SerializeField]
    private BoolRepherence frontWheelGrounded;
    [SerializeField]
    private BoolRepherence backWheelGrounded;

    [SerializeField]
    private Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        if (centerOfMass != null)
            rigidbody.centerOfMass = centerOfMass.localPosition;

        frontMotor = frontWheelJoint.motor;
        backMotor = backWheelJoint.motor;
    }

    // Update is called once per frame
    void Update()
    {
        //Driving
        frontMotor.motorSpeed = speed * -input.y;
        backMotor.motorSpeed = speed * -input.y;

        frontWheelJoint.motor = frontMotor;
        backWheelJoint.motor = backMotor;

        backWheelJoint.useMotor = input.y != 0;
        frontWheelJoint.useMotor = input.y != 0;

        //Leaning
        rigidbody.angularVelocity += leanPower * -input.x * Time.deltaTime;

        //Status
        Debug.DrawRay(frontWheelGameObject.transform.position, Vector3.down * wheelRadius, Color.yellow);
        Debug.DrawRay(backWheelGameObject.transform.position, Vector3.down * wheelRadius, Color.yellow);

        RaycastHit2D frontHit = Physics2D.Raycast(frontWheelGameObject.transform.position, Vector2.down, wheelRadius, wheelMask.value);
        RaycastHit2D backHit = Physics2D.Raycast(backWheelGameObject.transform.position, Vector2.down, wheelRadius, wheelMask.value);

        frontWheelGrounded.value = frontHit.transform != null;
        backWheelGrounded.value = backHit.transform != null;

        grounded.value = frontWheelGrounded || backWheelGrounded;
    }

    //Called by PlayerInput
    public void MovementEvent(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        this.input = input;
    }

    public void ResetEvent(InputAction.CallbackContext context)
    {
        transform.position = new Vector3(0,-2,0);
        transform.localEulerAngles = Vector3.zero;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0f;
    }
}
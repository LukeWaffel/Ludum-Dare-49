using UnityEngine;
using UnityEngine.InputSystem;

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
    private float speed = 1000f;
    [SerializeField]
    private float leanPower = 1000f;
    [SerializeField]
    private float wheelRadius = 0.4f;
    [SerializeField]
    private LayerMask wheelMask;

    [Header("Status")]
    public bool grounded;
    public bool frontWheelGrounded;
    public bool backWheelGrounded;

    [SerializeField]
    private Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
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

        frontWheelGrounded = frontHit.transform != null;
        backWheelGrounded = backHit.transform != null;

        grounded = frontWheelGrounded && backWheelGrounded;
    }

    //Called by PlayerInput
    public void MovementEvent(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        this.input = input;
    }

    public void ResetEvent(InputAction.CallbackContext context)
    {
        transform.GetChild(0).localPosition = Vector3.zero;
        transform.GetChild(0).localEulerAngles = Vector3.zero;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0f;
    }
}
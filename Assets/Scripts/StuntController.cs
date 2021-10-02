using ExpPlus.Phariables;
using UnityEngine;

public class StuntController : MonoBehaviour
{

    [Header("References")]
    [SerializeField]
    private Rigidbody2D vehicleRidigbody;

    [Header("Repherences")]
    [SerializeField]
    private BoolRepherence grounded;
    [SerializeField]
    private BoolRepherence frontWheelGrounded;
    [SerializeField]
    private BoolRepherence backWheelGrounded;

    [SerializeField]
    private float initialRotation;

    [SerializeField]
    private FloatRepherence wheelieCounter;
    [SerializeField]
    private FloatRepherence stoppieCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WheelieChecker();
        StoppieCheckcer();
    }

    private void WheelieChecker()
    {
        if (frontWheelGrounded.value == false && backWheelGrounded == true)
        {
            wheelieCounter.value += Time.deltaTime;
        }
        else
        {
            wheelieCounter.value = 0;
        }
    }

    private void StoppieCheckcer()
    {
        if (backWheelGrounded.value == false && frontWheelGrounded == true && vehicleRidigbody.velocity.x > 0)
        {
            stoppieCounter.value += Time.deltaTime;
        }
        else
        {
            stoppieCounter.value = 0;
        }
    }
}

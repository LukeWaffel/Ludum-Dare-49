using ExpPlus.Phariables;
using UnityEngine;

public class StuntController : MonoBehaviour
{

    [Header("References")]
    [SerializeField]
    private Rigidbody2D vehicleRidigbody;

    [Header("Grounded states")]
    [SerializeField]
    private BoolRepherence grounded;
    [SerializeField]
    private BoolRepherence frontWheelGrounded;
    [SerializeField]
    private BoolRepherence backWheelGrounded;

    [Header("Stunt States")]
    [SerializeField]
    private FloatRepherence wheelieCounter;
    [SerializeField]
    private FloatRepherence stoppieCounter;
    [SerializeField]
    private bool isUpsideDown;

    [Header("Events")]
    [SerializeField]
    private BoolRepherence didBackflip;
    [SerializeField]
    private BoolRepherence didFrontFlip;

    // Update is called once per frame
    void Update()
    {
        FlipCheck();
        WheelieChecker();
        StoppieCheckcer();
    }

    private void FlipCheck()
    {
        if (transform.eulerAngles.z >= 160f && transform.eulerAngles.z <= 200f)
            isUpsideDown = true;

        if (transform.eulerAngles.z < 160 && isUpsideDown)
        {

            if (vehicleRidigbody.angularVelocity > 0)
            {
                didBackflip.value = true;
            }
            else
            {
                didFrontFlip.value = true;
            }
        }
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

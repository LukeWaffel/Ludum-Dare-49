using UnityEngine;

public class StuintController : MonoBehaviour
{

    [Header("References")]
    [SerializeField]
    private VehicleController vehicleController;

    [SerializeField]
    private float initialRotation;

    [SerializeField]
    private float wheelieCounter;
    [SerializeField]
    private float stoppieCounter;

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
        if (vehicleController.frontWheelGrounded == false)
        {
            wheelieCounter += Time.deltaTime;
        }
        else
        {
            wheelieCounter = 0;
        }
    }

    private void StoppieCheckcer()
    {
        if (vehicleController.backWheelGrounded == false)
        {
            stoppieCounter += Time.deltaTime;
        }
        else
        {
            stoppieCounter = 0;
        }
    }
}

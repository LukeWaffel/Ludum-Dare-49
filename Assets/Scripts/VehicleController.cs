using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    [SerializeField]
    private Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovementEvent(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        //For debugging
        this.input = input;
    }
}

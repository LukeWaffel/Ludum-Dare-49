using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ExpPlus.Phariables;

public class PizzaDeliveryController : MonoBehaviour
{
    [SerializeField]
    private GameObject nearestCustomer;
    [SerializeField]
    private IntRepherence pizzasDelivered;

    public void DeliverPizzaEvent(InputAction.CallbackContext context)
    {
        if(nearestCustomer != null && nearestCustomer.tag == "Customer")
        {
            pizzasDelivered.value++;

            nearestCustomer.tag = "Untagged";
            nearestCustomer = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Customer")
        {
            nearestCustomer = collision.gameObject;
        }
    }
}

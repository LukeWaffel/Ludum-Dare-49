using UnityEngine;
using UnityEngine.InputSystem;
using ExpPlus.Phariables;

public class PizzaDeliveryController : MonoBehaviour
{
    [SerializeField]
    private GameObject nearestCustomer;
    [SerializeField]
    private IntRepherence pizzasDelivered;
    [SerializeField]
    private GameObject slicePrefab;

    public void DeliverPizzaEvent(InputAction.CallbackContext context)
    {
        if(nearestCustomer != null && nearestCustomer.tag == "Customer")
        {
            pizzasDelivered.value++;

            nearestCustomer.tag = "Untagged";
            nearestCustomer = null;

            GameObject spawnedSlice = Instantiate(slicePrefab, transform.position + new Vector3(-1f, 1f), Quaternion.identity);
            spawnedSlice.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, 2f), ForceMode2D.Impulse);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpPlus.Phariables;

public class TimeController : MonoBehaviour
{

    [Header("Events")]
    [SerializeField]
    private BoolRepherence pizzaDelivered;

    [Header("Status")]
    [SerializeField]
    private FloatRepherence secondsLeft;

    [Header("Config")]
    [SerializeField]
    private FloatRepherence secondsPerPizza;

    private void OnEnable()
    {
        pizzaDelivered.phariable.SubscribeToOnChangeSignal("triggered", PizzaDelivered);
    }

    private void OnDisable()
    {
        pizzaDelivered.phariable.UnSubscribeFromOnChangeSignal("triggered", PizzaDelivered);
    }

    private void Start()
    {
        secondsLeft.value = secondsPerPizza.value;
    }

    private void Update()
    {
        secondsLeft.value -= Time.deltaTime;
    }

    private void PizzaDelivered()
    {
        secondsLeft.value = secondsPerPizza.value;
    }
}

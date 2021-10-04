using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpPlus.Phariables;

public class TimeController : MonoBehaviour
{

    [Header("Repherences")]
    [SerializeField]
    private IntRepherence pizzasDelivered;

    [Header("Status")]
    [SerializeField]
    private FloatRepherence secondsLeft;

    [Header("Config")]
    [SerializeField]
    private FloatRepherence secondsPerPizza;

    private void OnEnable()
    {
        pizzasDelivered.phariable.SubscribeToOnChangeSignal("changed", PizzaDelivered);
    }

    private void OnDisable()
    {
        pizzasDelivered.phariable.UnSubscribeFromOnChangeSignal("changed", PizzaDelivered);
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

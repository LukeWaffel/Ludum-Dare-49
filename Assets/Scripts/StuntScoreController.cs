using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpPlus.Phariables;

public class StuntScoreController : MonoBehaviour
{
    [Header("Stunt score")]
    [SerializeField]
    private IntRepherence stuntScore;

    [Header("Events")]
    [SerializeField]
    private BoolRepherence didBackflip;
    [SerializeField]
    private BoolRepherence didFrontFlip;
    [SerializeField]
    private FloatRepherence wheelieCounter;
    [SerializeField]
    private FloatRepherence stoppieCounter;

    [Header("Stunt counters")]
    [SerializeField]
    private IntRepherence backflipCounter;
    [SerializeField]
    private IntRepherence frontflipCounter;
    [SerializeField]
    private FloatRepherence totalWheelieCounter;
    [SerializeField]
    private FloatRepherence totalStoppieCounter;

    [Header("Stunt values")]
    [SerializeField]
    private IntRepherence backflipValue;
    [SerializeField]
    private IntRepherence frontflipValue;
    [SerializeField]
    private IntRepherence wheelieValue;
    [SerializeField]
    private IntRepherence stoppieValue;

    private float previousActiveWheelie;
    private float previousActiveStoppie;

    private void OnEnable()
    {
        didBackflip.phariable.SubscribeToOnChangeSignal("triggered", DidBackflip);
        didFrontFlip.phariable.SubscribeToOnChangeSignal("triggered", DidFrontFlip);
        
        wheelieCounter.phariable.SubscribeToOnChangeSignal("active", WheelieActive);
        wheelieCounter.phariable.SubscribeToOnChangeSignal("ended", WheelieEnded);

        stoppieCounter.phariable.SubscribeToOnChangeSignal("active", StoppieActive);
        stoppieCounter.phariable.SubscribeToOnChangeSignal("ended", StoppieEnded);
    }

    private void OnDisable()
    {
        didBackflip.phariable.UnSubscribeFromOnChangeSignal("triggered", DidBackflip);
        didFrontFlip.phariable.UnSubscribeFromOnChangeSignal("triggered", DidFrontFlip);

        wheelieCounter.phariable.UnSubscribeFromOnChangeSignal("active", WheelieActive);
        wheelieCounter.phariable.UnSubscribeFromOnChangeSignal("ended", WheelieEnded);

        stoppieCounter.phariable.UnSubscribeFromOnChangeSignal("active", StoppieActive);
        stoppieCounter.phariable.UnSubscribeFromOnChangeSignal("ended", StoppieEnded);
    }

    private void DidBackflip()
    {
        backflipCounter.value++;
    }

    private void DidFrontFlip()
    {
        frontflipCounter.value++;
    }
    
    private void WheelieActive()
    {
        previousActiveWheelie = wheelieCounter.value;
    }

    private void WheelieEnded()
    {
        totalWheelieCounter.value += previousActiveWheelie;
        previousActiveWheelie = 0;
    }

    private void StoppieActive()
    {
        previousActiveStoppie = stoppieCounter.value;
    }

    private void StoppieEnded()
    {
        totalStoppieCounter.value += previousActiveStoppie;
        previousActiveStoppie = 0;
    }
}

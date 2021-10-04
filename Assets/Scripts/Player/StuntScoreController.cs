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
    private FloatRepherence activeWheelieCounter;
    [SerializeField]
    private FloatRepherence activeStoppieCounter;

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
        
        activeWheelieCounter.phariable.SubscribeToOnChangeSignal("active", WheelieActive);
        activeWheelieCounter.phariable.SubscribeToOnChangeSignal("ended", WheelieEnded);

        activeStoppieCounter.phariable.SubscribeToOnChangeSignal("active", StoppieActive);
        activeStoppieCounter.phariable.SubscribeToOnChangeSignal("ended", StoppieEnded);
    }

    private void OnDisable()
    {
        didBackflip.phariable.UnSubscribeFromOnChangeSignal("triggered", DidBackflip);
        didFrontFlip.phariable.UnSubscribeFromOnChangeSignal("triggered", DidFrontFlip);

        activeWheelieCounter.phariable.UnSubscribeFromOnChangeSignal("active", WheelieActive);
        activeWheelieCounter.phariable.UnSubscribeFromOnChangeSignal("ended", WheelieEnded);

        activeStoppieCounter.phariable.UnSubscribeFromOnChangeSignal("active", StoppieActive);
        activeStoppieCounter.phariable.UnSubscribeFromOnChangeSignal("ended", StoppieEnded);
    }

    private void RecalculateTotalScore()
    {

        stuntScore.value = 0;
        
        stuntScore.value += backflipCounter.value * backflipValue.value;
        stuntScore.value += frontflipCounter.value * frontflipValue.value;

        stuntScore.value += (int)(totalWheelieCounter.value * wheelieValue.value);
        stuntScore.value += (int)(totalStoppieCounter.value * stoppieValue.value);
    }

    private void DidBackflip()
    {
        backflipCounter.value++;
        RecalculateTotalScore();
    }

    private void DidFrontFlip()
    {
        frontflipCounter.value++;
        RecalculateTotalScore();
    }
    
    private void WheelieActive()
    {
        previousActiveWheelie = activeWheelieCounter.value;
    }

    private void WheelieEnded()
    {
        totalWheelieCounter.value += previousActiveWheelie;
        previousActiveWheelie = 0;
        RecalculateTotalScore();
    }

    private void StoppieActive()
    {
        previousActiveStoppie = activeStoppieCounter.value;
    }

    private void StoppieEnded()
    {
        totalStoppieCounter.value += previousActiveStoppie;
        previousActiveStoppie = 0;
        RecalculateTotalScore();
    }
}

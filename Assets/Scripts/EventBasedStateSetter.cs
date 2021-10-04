using ExpPlus.Phariables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventBasedStateSetter : MonoBehaviour
{

    [Header("Repherences")]
    [SerializeField]
    private IntRepherence intRepherence;
    [SerializeField]
    private BoolRepherence boolRepherence;
    [SerializeField]
    private FloatRepherence floatRepherence;

    [Header("Config")]
    [SerializeField]
    private string eventName;
    [SerializeField]
    private GameObject targetGameObject;
    [SerializeField]
    private bool targetState;

    private void OnEnable()
    {
        if(intRepherence.phariable != null)
        {
            intRepherence.phariable.SubscribeToOnChangeSignal(eventName, OnEvent);
        }else if(boolRepherence.phariable != null)
        {
            boolRepherence.phariable.SubscribeToOnChangeSignal(eventName, OnEvent);
        }
        else
        {
            floatRepherence.phariable.SubscribeToOnChangeSignal(eventName, OnEvent);
        }
    }

    private void OnDisable()
    {
        if (intRepherence.phariable != null)
        {
            intRepherence.phariable.UnSubscribeFromOnChangeSignal(eventName, OnEvent);
        }
        else if (boolRepherence.phariable != null)
        {
            boolRepherence.phariable.UnSubscribeFromOnChangeSignal(eventName, OnEvent);
        }
        else
        {
            floatRepherence.phariable.UnSubscribeFromOnChangeSignal(eventName, OnEvent);
        }
    }
    private void OnEvent()
    {
        targetGameObject.SetActive(true);
    }
}

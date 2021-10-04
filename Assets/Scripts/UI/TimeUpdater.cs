using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpPlus.Phariables;
using TMPro;

public class TimeUpdater : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private FloatRepherence secondsLeft;

    private void OnEnable()
    {
        secondsLeft.phariable.SubscribeToOnChangeSignal("changed", UpdateTime);
    }

    private void OnDisable()
    {
        secondsLeft.phariable.UnSubscribeFromOnChangeSignal("changed", UpdateTime);
    }

    private void UpdateTime()
    {
        text.text = $"Seconds remaining: {(int)secondsLeft.value}";
    }
}

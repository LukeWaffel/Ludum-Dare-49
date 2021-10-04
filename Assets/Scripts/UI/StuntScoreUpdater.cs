using ExpPlus.Phariables;
using TMPro;
using UnityEngine;

public class StuntScoreUpdater : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private TMP_Text text;

    [Header("Score")]
    [SerializeField]
    private IntRepherence score;

    private void OnEnable()
    {
        UpdateStatus();
        score.phariable.SubscribeToOnChangeSignal("changed", UpdateStatus);
    }

    private void OnDisable()
    {
        score.phariable.UnSubscribeFromOnChangeSignal("changed", UpdateStatus);
    }

    private void UpdateStatus()
    {
        text.text = $"Stunt score: {score.value}";
    }
}
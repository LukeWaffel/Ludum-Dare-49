using ExpPlus.Phariables;
using TMPro;
using UnityEngine;

public class DeliveryStatusUpdater : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private TMP_Text text;

    [Header("Pizza status")]
    [SerializeField]
    private IntRepherence pizzasToDeliver;
    [SerializeField]
    private IntRepherence pizzasDelivered;

    private void OnEnable()
    {
        UpdateStatus();
        pizzasDelivered.phariable.SubscribeToOnChangeSignal("changed", UpdateStatus);
    }

    private void OnDisable()
    {
        pizzasDelivered.phariable.UnSubscribeFromOnChangeSignal("changed", UpdateStatus);
    }

    private void UpdateStatus()
    {
        text.text = $"{pizzasDelivered.value}/{pizzasToDeliver.value}";
    }
}

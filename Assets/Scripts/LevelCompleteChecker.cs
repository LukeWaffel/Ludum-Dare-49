using UnityEngine;
using ExpPlus.Phariables;

public class LevelCompleteChecker : MonoBehaviour
{

    [SerializeField]
    private IntRepherence pizzasDelivered;
    [SerializeField]
    private IntRepherence pizzasToDeliver;
    [SerializeField]
    private FloatRepherence timeLeft;

    private void OnEnable()
    {
        pizzasDelivered.phariable.SubscribeToOnChangeSignal("changed", OnPizzaDelivered);
    }

    private void OnDisable()
    {
        pizzasDelivered.phariable.UnSubscribeFromOnChangeSignal("changed", OnPizzaDelivered);
    }

    private void OnPizzaDelivered()
    {
        timeLeft.value = 0f;
    }
}

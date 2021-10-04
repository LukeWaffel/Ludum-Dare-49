using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpPlus.Phariables;
using TMPro;

public class RunOverController : MonoBehaviour
{

    #region Top content
    [Header("Top content")]
    [SerializeField]
    private IntRepherence day;
    [SerializeField]
    private TMP_Text dayText;
    #endregion

    #region Left content
    [Header("Left content")]
    [SerializeField]
    private IntRepherence stuntScore;
    [SerializeField]
    private TMP_Text stuntScoreText;
    [SerializeField]
    private IntRepherence backflips;
    [SerializeField]
    private TMP_Text backflipsText;
    [SerializeField]
    private IntRepherence frontflips;
    [SerializeField]
    private TMP_Text frontflipsText;
    [SerializeField]
    private FloatRepherence wheelieTime;
    [SerializeField]
    private TMP_Text wheelieTimeText;
    [SerializeField]
    private FloatRepherence stoppieTime;
    [SerializeField]
    private TMP_Text stoppieTimeText;
    [SerializeField]
    private TMP_Text scoreAboveBelowText;
    [SerializeField]
    private TMP_Text customerGainedText;
    [SerializeField]
    private Color gainedColor;
    [SerializeField]
    private Color lostColor;
    #endregion
    #region Right content
    [Header("Right content")]
    [SerializeField]
    private IntRepherence pizzasDelivered;
    [SerializeField]
    private IntRepherence pizzasToDeliver;
    [SerializeField]
    private TMP_Text pizzasDeliveredText;
    [SerializeField]
    private FloatRepherence pricePerPizza;
    [SerializeField]
    private TMP_Text deliveredPizzaProfitText;
    [SerializeField]
    private FloatRepherence variableBusinessExpense;
    [SerializeField]
    private TMP_Text variableExpenseText;
    [SerializeField]
    private FloatRepherence fixedBusinessExpense;
    [SerializeField]
    private TMP_Text fixedExpenseText;
    [SerializeField]
    private TMP_Text profitText;
    [SerializeField]
    private FloatRepherence money;
    [SerializeField]
    private TMP_Text moneyText;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        OnOpen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnOpen()
    {
        dayText.text = day.value.ToString();

        stuntScoreText.text = stuntScore.value.ToString();
        backflipsText.text = backflips.value.ToString();
        frontflipsText.text = frontflips.value.ToString();
        wheelieTimeText.text = ((int)wheelieTime.value).ToString();
        stoppieTimeText.text = ((int)stoppieTime.value).ToString();

        scoreAboveBelowText.text = stuntScore.value >= 1000 ? "Stunt score is 1000 or higher" : "Stunt score is below 1000";
        customerGainedText.text = stuntScore.value >= 1000 ? "You gained a customer!" : "You lost a customer";
        customerGainedText.color = stuntScore.value >= 1000 ? gainedColor : lostColor;

        pizzasDeliveredText.text = $"{pizzasDelivered.value}/{pizzasToDeliver.value}";
        deliveredPizzaProfitText.text = $"${pizzasDelivered.value * pricePerPizza.value} ({pizzasDelivered.value} x ${pricePerPizza.value})";
        //deliveredPizzaProfitText.text = $"{pizzasDelivered.value} x ${pricePerPizza.value} = {pizzasDelivered.value * pricePerPizza.value}";

        variableExpenseText.text = $"${pizzasDelivered.value * variableBusinessExpense.value} ({pizzasDelivered.value} x ${variableBusinessExpense.value})";

        fixedExpenseText.text = $"${fixedBusinessExpense.value}";

        float profit = (pizzasDelivered.value * pricePerPizza.value) - (pizzasDelivered.value * variableBusinessExpense.value) - fixedBusinessExpense.value;
        profitText.text = $"${profit}";

        moneyText.text = $"${money.value}";
    }

    public void Continue()
    {

    } 

    public void Exit()
    {

    }
}

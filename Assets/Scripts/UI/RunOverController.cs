using UnityEngine;
using ExpPlus.Phariables;
using TMPro;
using UnityEngine.SceneManagement;

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
    private IntRepherence minimumStuntScore;
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
    private IntRepherence maxPizzasToDeliver;
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

    [Header("Game Over references")]
    [SerializeField]
    private GameObject gameOverText;
    [SerializeField]
    private GameObject gameOverExplainerText;
    [SerializeField]
    private TMP_Text continueButtonText;
    [SerializeField]
    private TMP_Text moneyLabel;

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
        dayText.text = $"Day: {day.value}";

        stuntScoreText.text = stuntScore.value.ToString();
        backflipsText.text = backflips.value.ToString();
        frontflipsText.text = frontflips.value.ToString();
        wheelieTimeText.text = ((int)wheelieTime.value).ToString();
        stoppieTimeText.text = ((int)stoppieTime.value).ToString();

        int desiredStuntScore = minimumStuntScore.value * pizzasToDeliver.value;

        if (stuntScore.value >= desiredStuntScore)
        {
            if(pizzasToDeliver.value < maxPizzasToDeliver.value)
            {
                customerGainedText.text = "You gained a customer!";
            }
            else
            {
                customerGainedText.text = "You're at max capacity.";
            }
        }
        else
        {
            if(pizzasToDeliver.value > 1)
            {
                customerGainedText.text = "You lost a customer";
            }
            else
            {
                customerGainedText.text = "You can't lose any more customers";
            }
        }

        scoreAboveBelowText.text = stuntScore.value >= desiredStuntScore ? $"Stunt score is {desiredStuntScore} or higher" : $"Stunt score is below {desiredStuntScore}";
        //customerGainedText.text = stuntScore.value >= minimumStuntScore.value ? "You gained a customer!" : "You lost a customer";
        customerGainedText.color = stuntScore.value >= desiredStuntScore ? gainedColor : lostColor;

        pizzasDeliveredText.text = $"{pizzasDelivered.value}/{pizzasToDeliver.value}";
        deliveredPizzaProfitText.text = $"${pizzasDelivered.value * pricePerPizza.value} ({pizzasDelivered.value} x ${pricePerPizza.value})";
        //deliveredPizzaProfitText.text = $"{pizzasDelivered.value} x ${pricePerPizza.value} = {pizzasDelivered.value * pricePerPizza.value}";

        variableExpenseText.text = $"${pizzasDelivered.value * variableBusinessExpense.value} ({pizzasDelivered.value} x ${variableBusinessExpense.value})";

        fixedExpenseText.text = $"${fixedBusinessExpense.value}";

        float profit = (pizzasDelivered.value * pricePerPizza.value) - (pizzasDelivered.value * variableBusinessExpense.value) - fixedBusinessExpense.value;
        profitText.text = $"${profit}";

        money.value += profit;
        moneyText.text = $"${money.value}";

        //Reset and configure variabvles
        day.value++;
        pizzasDelivered.value = 0;
        wheelieTime.value = 0;
        stoppieTime.value = 0;
        backflips.value = 0;
        frontflips.value = 0;

        if(stuntScore >= desiredStuntScore)
        {
            pizzasToDeliver.value++;
            pizzasToDeliver.value = Mathf.Clamp(pizzasToDeliver.value, 0, maxPizzasToDeliver.value);
        }

        //GameOver state
        if (money.value < 0)
        {
            day.value = 0;
            money.value = 0;

            gameOverText.SetActive(true);
            gameOverExplainerText.SetActive(true);
            continueButtonText.text = "Restart";

            Color gameOverColor = gameOverText.GetComponent<TMP_Text>().color;
            moneyText.color = gameOverColor;
            moneyLabel.color = gameOverColor;
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene("game");
    } 

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

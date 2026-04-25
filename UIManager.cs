using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Game Reference")]
    public BaccaratGameManager game; // Drag your BaccaratGameManager here

    [Header("Text Fields")]
    public TMP_Text balanceText;
    public TMP_Text resultText;

    [Header("Bet Buttons")]
    public Button betPlayerBtn;
    public Button betBankerBtn;
    public Button betTieBtn;

    [Header("Chip Buttons")]
    public Button chip5;
    public Button chip25;
    public Button chip100;

    [Header("Deal Button")]
    public Button dealBtn;

    private string selectedBet = "Player";
    private int betAmount = 0;

    void Start()
    {
        UpdateBalanceText();
        UpdateResultText("Place your bet!");
    }

    // --- Public Methods for Buttons ---
    public void SelectBetPlayer() { SelectBet("Player"); }
    public void SelectBetBanker() { SelectBet("Banker"); }
    public void SelectBetTie() { SelectBet("Tie"); }

    public void AddChip5() { AddBet(5); }
    public void AddChip25() { AddBet(25); }
    public void AddChip100() { AddBet(100); }

    public void DealRound()
    {
        if (game == null)
        {
            Debug.LogError("BaccaratGameManager is not assigned!");
            return;
        }

        if (betAmount <= 0)
        {
            UpdateResultText("Place a bet first!");
            return;
        }

        game.PlayRound(selectedBet, betAmount);

        UpdateBalanceText();
        ShowResult();

        betAmount = 0; // Reset after each round
    }

    // --- Private helper methods ---
    private void SelectBet(string bet)
    {
        selectedBet = bet;
        UpdateResultText($"Bet: {betAmount} on {selectedBet}");
    }

    private void AddBet(int amount)
    {
        betAmount += amount;
        UpdateResultText($"Bet: {betAmount} on {selectedBet}");
    }

    private void UpdateBalanceText()
    {
        if (balanceText != null && game != null)
            balanceText.text = "Balance: " + game.balance;
    }

    private void UpdateResultText(string text)
    {
        if (resultText != null)
            resultText.text = text;
    }

    private void ShowResult()
    {
        if (game == null) return;

        int playerValue = game.player.Value();
        int bankerValue = game.banker.Value();

        if (playerValue > bankerValue) UpdateResultText("PLAYER WINS!");
        else if (bankerValue > playerValue) UpdateResultText("BANKER WINS!");
        else UpdateResultText("TIE!");
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

// After other classes have been created, uncomment everything in this class.
public class TicTacToeUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField]private Button[] boardButtons;
    [SerializeField]private TMP_Text currentPlayerText;
    [SerializeField]private TMP_Text gameResultText;
    [SerializeField]private Button resetButton;
    
    
    private TicTacToeGame _game;

    private void Start()
    {
        _game = new TicTacToeGame();
        InitializeBoard();
        UpdateCurrentPlayerText();
        gameResultText.text = "";
        resetButton.onClick.AddListener(ResetGame);
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < boardButtons.Length; i++)
        {
            int row = i / 3;
            int col = i % 3;
            boardButtons[i].onClick.RemoveAllListeners(); // Clear any existing listeners
            boardButtons[i].onClick.AddListener(() => OnBoardButtonClick(row, col));
            boardButtons[i].GetComponentInChildren<TMP_Text>().text = "";
            boardButtons[i].interactable = true;
        }
    }

    private void OnBoardButtonClick(int row, int col)
    {
        bool moveMade = _game.MakeMove(row, col);
        if (moveMade)
        {
            UpdateBoard();
            if (_game.CurrentState == GameState.Ongoing)
            {
                UpdateCurrentPlayerText();
            }
            else
            {
                EndGame();
            }
        }
    }

    private void UpdateBoard()
    {
        for (int i = 0; i < boardButtons.Length; i++)
        {
            int row = i / 3;
            int col = i % 3;
            Player playerAtPosition = _game.GetPlayerAtPosition(row, col);
            boardButtons[i].GetComponentInChildren<TMP_Text>().text = playerAtPosition == Player.None ? "" : playerAtPosition.ToString();
            boardButtons[i].interactable = playerAtPosition == Player.None && _game.CurrentState == GameState.Ongoing;
        }
    }

    private void UpdateCurrentPlayerText()
    {
        currentPlayerText.text = $"Current Player: {_game.CurrentPlayer}";
    }

    private void EndGame()
    {
        gameResultText.text = _game.GetGameResult();
        foreach (Button button in boardButtons)
        {
            button.interactable = false;
        }
    }

    private void ResetGame()
    {
        _game.ResetGame();
        InitializeBoard();
        UpdateCurrentPlayerText();
        gameResultText.text = "";
    }
   
}

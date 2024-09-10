using UnityEngine;
using TMPro;

public class GameRunner : MonoBehaviour
{
    private TicTacToeGame _game;
    [SerializeField] private TMP_Text currentPlayerText;
    [SerializeField] private TMP_Text gameResultText;
    [SerializeField] private GameObject xPrefab;
    [SerializeField] private GameObject oPrefab;

    // This array will hold the instantiated board objects
    private GameObject[,] _boardObjects;

    private void Start()
    {
        _game = new TicTacToeGame();
        _game.InitializeGame();

        // Initialize the _boardObjects array here
        _boardObjects = new GameObject[3, 3];

        UpdateCurrentPlayerText();
        gameResultText.text = "";
    }

    public void InitializeBoard()
    {
        //Clear the board
        if (_boardObjects != null)
        {
            foreach (var obj in _boardObjects)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }
            }
        }
        _boardObjects = new GameObject[3, 3];
        //Reset all the text
    }

    public void OnBoardButtonClick(int row, int col, Vector3 position)
    {
        // Adjust for zero-based indexing
        int adjustedRow = row - 1;  // Convert Unity's 1-based indexing to 0-based indexing
        int adjustedCol = col - 1;  // Convert Unity's 1-based indexing to 0-based indexing

        // Make the move using adjusted row and column
        bool moveMade = _game.MakeMove(adjustedRow, adjustedCol);

        if (moveMade)
        {
            // Update the board with adjusted row and column
            UpdateBoard(adjustedRow, adjustedCol, position);

            if (_game.CurrentState == GameState.Ongoing)
            {
                UpdateCurrentPlayerText();  // Continue the game if ongoing
            }
            else
            {
                EndGame();  // End the game (win or draw)
            }
        }
    }


    private void UpdateBoard(int row, int col, Vector3 position)
    {
        // We now use the position of the button directly, passed from the Interact method in BoardButton
        Vector3 buttonPosition = new Vector3(position.x, position.y, position.z);  // Already set by the board button

        // Get the player at the current position
        Player playerAtPosition = _game.GetPlayerAtPosition(row, col);

        // Instantiate X or O based on the current player
        if (playerAtPosition == Player.X)
        {
            _boardObjects[row, col] = Instantiate(xPrefab, buttonPosition, Quaternion.identity);
        }
        else if (playerAtPosition == Player.O)
        {
            _boardObjects[row, col] = Instantiate(oPrefab, buttonPosition, Quaternion.Euler(90, 0, 0));  // Adjust rotation for O
        }
    }

    private void UpdateCurrentPlayerText()
    {
        // update which player is currently playing
        currentPlayerText.text = $"Current Player: {_game.CurrentPlayer}";
    }

    private void EndGame()
    {
        // update and display who won the game
        gameResultText.text = _game.GetGameResult();

    }

    public void ResetGame()
    {
        // reset the game
        _game.ResetGame();
        InitializeBoard();
        UpdateCurrentPlayerText();
        gameResultText.text = "";
    }
}
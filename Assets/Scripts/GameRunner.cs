
using UnityEngine;
using TMPro;
using static UnityEngine.Rendering.DebugUI.Table;

public class GameRunner : MonoBehaviour
{
    private TicTacToeGame _game;
    [SerializeField]private TMP_Text currentPlayerText;
    [SerializeField]private TMP_Text gameResultText;
    [SerializeField]private GameObject xPrefab;
    [SerializeField]private GameObject oPrefab;

    // This array will hold the instantiated board objects
    private GameObject[,] _boardObjects = new GameObject[3, 3];

    private void Start()
    {
        _game = new TicTacToeGame();
        _game.InitializeGame();
        UpdateCurrentPlayerText();
        gameResultText.text = "";
        InitializeBoard();
    }

    public void InitializeBoard()
    {
        //Clear the board
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (_boardObjects[row, col] != null)
                {
                    Destroy(_boardObjects[row, col]);
                    _boardObjects[row, col] = null;
                }
            }
        }
        //Reset all the text

        gameResultText.text = "";
    }

    public void OnBoardButtonClick(int row, int col, Vector2 position)
    {
        //Make the move
        bool moveMade = _game.MakeMove(row - 1, col - 1);
        Debug.Log("AAAAAAAAAAAa");

        //If the move is valid,
        if (row < 0 || row > 3 || col < 0 || col > 3)
        {
            Debug.Log("RETURNING");
            return;
        }

        //Update the board
        if (moveMade)
        {
            Debug.Log("MAKING MOVE");

            UpdateBoard(position, row, col);  

            
            if (_game.CurrentState == GameState.Ongoing)
            {
                UpdateCurrentPlayerText();  
            }
            else
            {
                EndGame();  
            }
        }
        //Update the game state, check if the game is over


    }

    private void UpdateBoard(Vector2 position, int row, int col)
    {
        // Check the game values and update the board by instantiating correct prefab objects.    
        row -= 1; col -= 1;
        Vector3 aa = new Vector3(position.x, 0.086f, position.y);
        Player playerAtPosition = _game.GetPlayerAtPosition(row, col);
        Debug.LogWarning(position);

        if (playerAtPosition == Player.X)
        {
            _boardObjects[row, col] = Instantiate(xPrefab, aa, Quaternion.identity);
        }
        else if (playerAtPosition == Player.O)
        {
            _boardObjects[row, col] = Instantiate(oPrefab, aa, Quaternion.identity);
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
    }
}

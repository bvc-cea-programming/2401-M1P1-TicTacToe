
using UnityEngine;
using TMPro;

public class GameRunner : MonoBehaviour
{
    private TicTacToeGame _game;
    [SerializeField]private TMP_Text currentPlayerText;
    [SerializeField]private TMP_Text gameResultText;
    [SerializeField]private GameObject xPrefab;
    [SerializeField]private GameObject oPrefab;
    [SerializeField]private GameObject gameBoard;

    // This array will hold the instantiated board objects
    private GameObject[,] _boardObjects;
    //also have an empty GameObject to hold the pieces
    private GameObject pieces;

    private void Start()
    {
        _game = new TicTacToeGame();
        _game.InitializeGame();
        UpdateCurrentPlayerText();
        gameResultText.text = "";
        pieces = new GameObject("Pieces");
        _boardObjects = new GameObject[3, 3];
    }

    public void InitializeBoard()
    {
        //Clear the board
        //Reset all the text
        foreach (GameObject piece in _boardObjects){ 
        Destroy( piece );
        }
        gameResultText.text = "";
        _game.InitializeGame();
        UpdateCurrentPlayerText();
    }

    public void OnBoardButtonClick(int row, int col, Vector2 position)
    {
        //Make the move

        //If the move is valid,
        //Update the board
        //Update the game state, check if the game is over
        bool moveMade = _game.MakeMove(row, col);
        if (moveMade)
        {
            UpdateBoard(row, col, position);
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

    private void UpdateBoard(int row, int col, Vector2 position)
    {
        // Check the game values and update the board by instantiating correct prefab objects.    
        if (_game.CurrentPlayer == Player.X)
        {   //because this is player X's turn after the move is made, we place O and vice versa
            _boardObjects[row, col] = Instantiate(oPrefab, new Vector3(position.x, 0.1f, position.y), Quaternion.Euler(90, 0, 0), pieces.transform);
        } else if (_game.CurrentPlayer == Player.O)
        {
            _boardObjects[row, col] = Instantiate(xPrefab, new Vector3(position.x, 0.1f, position.y), Quaternion.identity, pieces.transform);
        }
    }
    
    private void UpdateCurrentPlayerText()
    {
        // update which player is currently playing
        currentPlayerText.text = $"Current Player: {_game.CurrentPlayer}";
    }

    private void EndGame()
    {
        //empty out current player text
        currentPlayerText.text = "";
        // update and display who won the game
        if (_game.CurrentState == GameState.Draw)
        {
            gameResultText.text = "Draw Game";
        }
        else if (_game.CurrentState == GameState.Win)
        {
            if (_game.CurrentPlayer == Player.X)
            {
                gameResultText.text = "Player O Wins";
            }
            else 
            {
                gameResultText.text = "Player X Wins";
            }
            
        }
    }

    public void ResetGame()
    {
        // reset the game
        Debug.Log("game reset");
        InitializeBoard();
    }
}

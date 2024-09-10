
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameRunner : MonoBehaviour
{
    private TicTacToeGame _game;
    [SerializeField]private TMP_Text currentPlayerText;
    [SerializeField]private TMP_Text gameResultText;
    [SerializeField]private GameObject xPrefab;
    [SerializeField]private GameObject oPrefab;

    // This array will hold the instantiated board objects
    private GameObject[,] _boardObjects; 
    
    private void Start()
    {
        _game = new TicTacToeGame();
        _game.InitializeGame();
        UpdateCurrentPlayerText();
        gameResultText.text = "";
    }

    public void InitializeBoard()
    {
        //Clear the board
        //Reset all the text
    }

    public void OnBoardButtonClick(int row, int col, Vector2 position)
    {
        //Make the move
        bool moveMade = _game.MakeMove(row, col);

        //If the move is valid,
        //Update the board
        if(moveMade)
        {
            UpdateBoard(position);
            if(_game.CurrentState == GameState.Ongoing)
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

    private void UpdateBoard(Vector2 position)
    {
        // Check the game values and update the board by instantiating correct prefab objects.
        
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
        // rese the game
        _game.ResetGame();
        InitializeBoard();
        UpdateCurrentPlayerText();
        gameResultText.text = "";
    }
}

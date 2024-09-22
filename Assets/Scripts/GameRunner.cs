
using UnityEngine;
using TMPro;

public class GameRunner : MonoBehaviour
{
    private TicTacToeGame _game;
    [SerializeField]private TMP_Text currentPlayerText;
    [SerializeField]private TMP_Text gameResultText;
    [SerializeField]private GameObject xPrefab;
    [SerializeField]private GameObject oPrefab;

    
    

    // This array will hold the instantiated board objects
    private GameObject[,] _boardObjects = new GameObject[3,3];
    

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
            for(int col = 0; col < 3; col++)
            {
                if (_boardObjects[row,col] != null) 
                {
                    Destroy(_boardObjects[row,col]);
                }
            }
        }
        gameResultText.text = "";
        UpdateCurrentPlayerText ();
        //Reset all the text
    }

    public void OnBoardButtonClick(int row, int col, Vector2 position)
    {
        if (_game.MakeMove(row, col))
        {
            UpdateBoard(row, col, position);
            if(_game.CheckWinCondition(row,col) || _game.CheckDrawCondition())
            {
                EndGame();
            }
            else
            {
                UpdateCurrentPlayerText();
            }
        }
        //If the move is valid,
        //Update the board
        //Update the game state, check if the game is over
        
        
    }

    private void UpdateBoard(int row, int col, Vector2 position)
    {
        // Check the game values and update the board by instantiating correct prefab objects.
        Player playerAtPosition = _game.GetPlayerAtPosition(row,col);
        if (playerAtPosition == Player.X)
        {
            _boardObjects[row,col] = Instantiate(xPrefab, new Vector3(position.x,0.1f,position.y), Quaternion.identity);
        }
        else if (playerAtPosition == Player.O)
        {
            _boardObjects[row,col] = Instantiate(oPrefab, new Vector3(position.x, 0.1f, position.y), Quaternion.identity);
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
        // rese the game
        InitializeBoard();
        _game.ResetGame();
        
    }

    


}

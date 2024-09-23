
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
        if(_boardObjects == null)
            _boardObjects=new GameObject[3,3];
        else 
        {
            for(int row=0;row<3;row++)
            {
                for(int col=0;col<3;col++)
                {
                    Destroy(_boardObjects[row,col]);
                    _boardObjects[row,col] = null;
                }
            }
            _boardObjects = new GameObject[3, 3];
        }
        //Clear the board
        //Reset all the text
    }

    public void OnBoardButtonClick(int row, int col, Vector2 position)
    {
        //Make the move
        if(_game.MakeMove(row,col))
        {
            UpdateBoard(row, col, position);

            if (_game.CurrentState==GameState.Ongoing)
            {
                UpdateCurrentPlayerText();
            }
            else 
            {
                EndGame();
            }
            //If the move is valid,
            //Update the board
            //Update the game state, check if the game is over
        }



    }

    private void UpdateBoard(int row, int col, Vector2 position)
    {
        if(_game.GetPlayerAtPosition(row,col)== Player.O && _boardObjects[row,col]==null)
        {
            _boardObjects[row, col] = Instantiate(oPrefab, position, Quaternion.Euler(0, 45, 0));
        }
        if (_game.GetPlayerAtPosition(row, col) == Player.X && _boardObjects[row, col] == null)
        {
            _boardObjects[row, col] = Instantiate(xPrefab, position, Quaternion.Euler(90, 0, 0));
        }
        // Check the game values and update the board by instantiating correct prefab objects.    
    }
    
    private void UpdateCurrentPlayerText()
    {
        // update which player is currently playing
        currentPlayerText.text = $"Player : {_game.CurrentPlayer}";
       
    }

    private void EndGame()
    {
        // update and display who won the game
        gameResultText = null;
        
    }

    public void ResetGame()
    {
        _game.ResetGame();
        InitializeBoard();
        UpdateCurrentPlayerText();
        // reset the game
    }
}

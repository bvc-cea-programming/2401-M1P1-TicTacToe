
using UnityEngine;
using TMPro;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.UIElements;
using Unity.Burst.CompilerServices;

public class GameRunner : MonoBehaviour
{
    private TicTacToeGame _game;
    [SerializeField]private TMP_Text currentPlayerText;
    [SerializeField]private TMP_Text gameResultText;
    [SerializeField]private GameObject xPrefab;
    [SerializeField]private GameObject oPrefab;

    private BoardInteractor boardInteractor;

    // This array will hold the instantiated board objects
    public GameObject[,] _boardObjects; 
    
    private void Start()
    {
        _game = new TicTacToeGame();
        _game.InitializeGame();
        UpdateCurrentPlayerText();
        gameResultText.text = "";
        InitializeBoard();

        boardInteractor = GetComponent<BoardInteractor>();
    }
  

    public void InitializeBoard()
    {
        //Clear the board
        //Reset all the text
        if(_boardObjects == null)
        {
            _boardObjects = new GameObject[3, 3];
        }
        
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                
                if (_boardObjects[row, col] != null)
                {
                    Destroy( _boardObjects[row, col] );
                }
                
            }
        }
        currentPlayerText.text = "Current Player: X";
        gameResultText.text = "";
    }

    public void OnBoardButtonClick(int row, int col, Vector3 position)
    {

        //Make the move
        //_game.MakeMove(row,col);
        bool isMovedValid = _game.IsValidMove(row, col);

       
        if (!isMovedValid) 
        {
            Debug.Log("row is :" + row);
            Debug.Log("col is :" + col);
        }
        //If the move is valid, Update the board
        if (_game.MakeMove(row,col))
        {
            UpdateBoard(row,col, position);
        }
        else
        {
            EndGame();
        }
        //Update the game state, check if the game is over

        // _game.GetGameResult();

        if (_game.CurrentState == GameState.Win)
        {
            gameResultText.text =$"Player {_game.CurrentPlayer} wins!"; }
        else if (_game.CurrentState == GameState.Ongoing)
        {
            gameResultText.text = "The game is ongoing";
        }
        else if(_game.CurrentState == GameState.Draw)
        {
            gameResultText.text = "The game is Draw";
        }

    }

    public void UpdateBoard(int row,int col,Vector3 position)
    {
        GameObject boardObject ;
        UpdateCurrentPlayerText();
        Debug.Log("currentPlayer is" + _game.CurrentPlayer);
        // Check the game values and update the board by instantiating correct prefab objects.
        if (_game.CurrentPlayer == Player.X)
        {
           
            boardObject =  Instantiate(xPrefab, position, Quaternion.identity);
            boardObject.transform.rotation = Quaternion.Euler(0, 45, 0);
            
        }
        else
        {
            boardObject = Instantiate(oPrefab, position, Quaternion.identity);
            boardObject.transform.rotation = Quaternion.Euler(90, 90, 0);

        }
        _boardObjects[row,col] = boardObject;
    }
    
    private void UpdateCurrentPlayerText()
    {
        // update which player is currently playing
        if (_game.CurrentPlayer == Player.X)
        {
            currentPlayerText.text = "Current Player: X";
        }
        else {
            currentPlayerText.text = "Current Player O";
           
        }
       // _game.SwitchPlayer();
    }

    private void EndGame()
    {
        // update and display who won the game
        _game.ResetGame();
        InitializeBoard();
        UpdateCurrentPlayerText();
        gameResultText.text = "";
    }

    public void ResetGame()
    {
        // reset the game
        InitializeBoard();
    }
}

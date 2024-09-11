
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

        boardInteractor = GetComponent<BoardInteractor>();
    }
  

    public void InitializeBoard()
    {
        //Clear the board
        //Reset all the text
        for (int i = 0; i < _boardObjects.Length;i++)
        {
            int row = i / 3;
            int col = i % 3;    
            
            gameResultText.text = "";
        }
    }

    public void OnBoardButtonClick(int row, int col, Vector3 position)
    {

        //Make the move
        bool  isMoved = _game.MakeMove(row, col);

        //If the move is valid, Update the board
        if (isMoved)
        {
            UpdateBoard(position);
        }
        else
        {
            EndGame();
        }
        //Update the game state, check if the game is over
    }

    public void UpdateBoard(Vector3 position)
    {
        // Check the game values and update the board by instantiating correct prefab objects.
        if(_game.CurrentPlayer == Player.X)
        {
          GameObject boardObject =  Instantiate(xPrefab, position, Quaternion.identity);
            boardObject.transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            GameObject boardObject = Instantiate(oPrefab, position, Quaternion.identity);
            boardObject.transform.rotation = Quaternion.Euler(90, 90, 0);

        }
        
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
        _game.SwitchPlayer();
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
        // rese the game
    }
}

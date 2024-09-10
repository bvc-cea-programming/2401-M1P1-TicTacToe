
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
        //Clear the board
        //Reset all the text
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

        currentPlayerText.text = "Player X's Turn";
        gameResultText.text = "";
    }

    public void OnBoardButtonClick(int row, int col, Vector2 position)
    {
        //Make the move
        _game.MakeMove(row , col);
        //If the move is valid,
        //Update the board
        //Update the game state, check if the game is over
        
        
    }

    private void UpdateBoard(Vector2 position)
    {
        // Check the game values and update the board by instantiating correct prefab objects.    
    }
    
    private void UpdateCurrentPlayerText()
    {
        // update which player is currently playing
    }

    private void EndGame(string result)
    {
        // update and display who won the game
        _game.GetGameResult();
        gameResultText.text = result;   
    }

    public void ResetGame()
    {
        // reset the game
        _game.ResetGame();
    }
}

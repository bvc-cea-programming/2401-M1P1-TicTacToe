
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
    
    public GameObject[,] _boardObjects = new GameObject[3,3]; 
    
    private void Start()
    {
        _game = new TicTacToeGame();
        _game.InitializeGame();
        UpdateCurrentPlayerText();
        gameResultText.text = "";
    }

    public void InitializeBoard()
    {
        for(int i = 0; i < _boardObjects.GetLength(0); i++)
        {
            for(int j = 0;  j < _boardObjects.GetLength(1); j++)
            {
                Destroy(_boardObjects[i, j]);
            }
            
        }
        currentPlayerText.SetText("");
        gameResultText.SetText("");
        //Clear the board
        //Reset all the text
    }

    public void OnBoardButtonClick(int row, int col, Vector2 position)
    {
        //Make the move
        bool moveMade = _game.MakeMove(row - 1, col - 1);
        if (moveMade)
        {
           
            UpdateBoard(row - 1, col - 1, position);
            if (_game.CurrentState == GameState.Ongoing)
            {
                UpdateCurrentPlayerText();
            }
            else
            {
                EndGame();
            }
        }
          
          
              //If the move is valid,
        //Update the board
        //Update the game state, check if the game is over
        
        
    }

    private void UpdateBoard(int row, int col, Vector2 position)
    {
        GameObject currentPrefab = _game.CurrentPlayer == Player.X ? oPrefab : xPrefab;
      GameObject obj = Instantiate(currentPrefab,new Vector3(position.x,0.2f,position.y),Quaternion.identity);
        _boardObjects[row,col] = obj;
        // Check the game values and update the board by instantiating correct prefab objects.    
    }
    
    private void UpdateCurrentPlayerText()
    {
        currentPlayerText.SetText(_game.CurrentPlayer.ToString());
        // update which player is currently playing
    }

    private void EndGame()
    {
        
            gameResultText.SetText(_game.GetGameResult());
        
        // update and display who won the game
        
    }

    public void ResetGame()
    {
        InitializeBoard();
        _game.ResetGame();
        // rese the game
    }
}

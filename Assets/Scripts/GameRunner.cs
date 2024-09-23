
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
    }

    public void InitializeBoard()
    {
        //Clear the board

	for(int x = 0; x < _boardObjects.GetLength(0); x++)
        {
            for(int y = 0; y < _boardObjects.GetLength(1); y++)
            {
                Destroy( _boardObjects[x, y]);
            }
        }

        //Reset all the text
        currentPlayerText.SetText("");
        gameResultText.SetText("");
    }

    public void OnBoardButtonClick(int row, int col, Vector2 position)
    {
        //Make the move
        if(_game.MakeMove(row, col))
        {
            UpdateBoard(row, col, position);
            if(_game.CurrentState == GameState.Ongoing)
            {
                UpdateCurrentPlayerText();
            }
            else
            {
                EndGame(_game.GetGameResult());
            }
        }
        //If the move is valid,
        //Update the board
        //Update the game state, check if the game is over
        
        
    }

    private void UpdateBoard( int row, int col, Vector2 position)
    {
        // Check the game values and update the board by instantiating correct prefab objects.
	GameObject currentPrefab = _game.CurrentPlayer == Player.X ? oPrefab : xPrefab;
      GameObject obj = Instantiate(currentPrefab,new Vector3(position.x,0.1f,position.y),Quaternion.identity);
        _boardObjects[row,col] = obj;
    }
    
    private void UpdateCurrentPlayerText()
    {
        // update which player is currently playing
	currentPlayerText.SetText(_game.CurrentPlayer.ToString());
    }

    private void EndGame(string result)
    {
        // update and display who won the game
        gameResultText.SetText(result);   
    }

    public void ResetGame()
    {
        // reset the game
	InitializeBoard();
        _game.ResetGame();
    }
}


using UnityEngine;
using TMPro;

public class GameRunner : MonoBehaviour
{
    private TicTacToeGame _game;
    [SerializeField]private TMP_Text currentPlayerText;
    [SerializeField]private TMP_Text gameResultText;
    [SerializeField]private GameObject xPrefab;
    [SerializeField]private GameObject oPrefab;
    [SerializeField]private float heightAboveBoard;

    // This array will hold the instantiated board objects
    private GameObject[,] _boardObject = new GameObject[3, 3];
    
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
        for(int x = 0; x < _boardObject.GetLength(0); x++)
        {
            for(int y = 0; y < _boardObject.GetLength(1); y++)
            {
                Destroy( _boardObject[x, y]);
            }
        }
        //Reset all the text
        gameResultText.SetText("");
        currentPlayerText.SetText("");
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
                EndGame();
            }
        }
        //If the move is valid,
        //Update the board
        //Update the game state, check if the game is over
    }

    private void UpdateBoard(int row, int col, Vector2 position)
    {
        // Check the game values and update the board by instantiating correct prefab objects.
        GameObject prefab = _game.CurrentPlayer == Player.X ? xPrefab : oPrefab;
        GameObject _placedObject = Instantiate(prefab, new Vector3(position.x, heightAboveBoard, position.y), Quaternion.identity);
        _boardObject[row, col] = _placedObject;
    }
    
    private void UpdateCurrentPlayerText()
    {
        // update which player is currently playing
        currentPlayerText.SetText(_game.CurrentPlayer.ToString());
    }

    private void EndGame()
    {
        // update and display who won the game
        gameResultText.SetText(_game.GetGameResult());
        
    }

    public void ResetGame()
    {
        // rese the game
        InitializeBoard();
        _game.ResetGame();
    }
}

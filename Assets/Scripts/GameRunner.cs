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
    //row, col of what the board's piece is, inside is supposed to be a Player enum
    
    private void Start()
    {
        _game = new TicTacToeGame();
        _game.InitializeGame();
        UpdateCurrentPlayerText();
        gameResultText.text = "";
        _boardObjects = new GameObject[3, 3];
        Debug.Log(_game.CurrentPlayer);
    }

    public void InitializeBoard()
    {
        //Clear the board
        foreach(var board in _boardObjects)
        {
            if (board != null)
            {
                Destroy(board);
            }
        }

        //Reset all the text
        gameResultText.text = "";

    }

    public void OnBoardButtonClick(int row, int col, Vector2 position)
    {
        //Make the move
        bool moveMade = _game.MakeMove(row, col);
        Debug.Log(_game.CurrentPlayer);

        //If the move is valid,
        //Update the board
        //Update the game state, check if the game is over
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
        //Used Ternary Operator to check if current player = X instantiate xPrefab, if not instantiate oPrefab.
        //So basically it supposed to be _game.currentPlayer == Player.X ? xPrefab : oPrefab. For now if current player = X
        //when we click it will make move and change current player to O that make UpdateBoard instantiate oPrefab becasuse of now current player is O
        //So I used _game.GetPlayerAtPosition(row, col) because it used enum player to check the result of player in the board instead of current player from the game
        //If now current player = X, when we click to the board, the result will be X. Then we use that result to instantiate the prefab
        GameObject currentPrefab = _game.GetPlayerAtPosition(row, col) == Player.X ? xPrefab : oPrefab;
        if (currentPrefab == xPrefab)
        {
            GameObject prefabSpawn = Instantiate(currentPrefab, new Vector3(position.x, 0.1f, position.y), Quaternion.Euler(0, -45, 0));
            _boardObjects[row, col] = prefabSpawn;
        }
        else if (currentPrefab == oPrefab)
        {
            GameObject prefabSpawn = Instantiate(currentPrefab, new Vector3(position.x, 0.1f, position.y), Quaternion.Euler(90, 0, 0));
            _boardObjects[row, col] = prefabSpawn;
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
        _game.ResetGame();
        InitializeBoard();
        UpdateCurrentPlayerText();
        gameResultText.text = "";
    }
}

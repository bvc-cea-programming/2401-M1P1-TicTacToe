
using UnityEngine;
using TMPro;
using System;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.UIElements;
using System.Collections.Generic;

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
        Destroy(xPrefab);
        Destroy(oPrefab);
        _game._movesMade = 0;
        //Reset all the text
        currentPlayerText.text = "Player1's turn";
        gameResultText.text = "";

    }

    public void OnBoardButtonClick(int row, int col, Vector2 position)
    {
        //If the move is valid,
        if ((row >= 1 || row <= 3 || col >= 1 || col <= 3) && (gameResultText.text.Equals("")))
        {
            bool moveMade = _game.MakeMove(row, col);
            if (moveMade)
            {
                UpdateBoard(row, col, position);
                if (_game.CurrentState == GameState.Ongoing)
                {
                    UpdateCurrentPlayerText();
                }
                else
                {
                    EndGame(row, col);
                }
            }
        }

    }

    private void UpdateBoard(int row, int col, Vector2 position)
    {
        // Check the game values and update the board by instantiating correct prefab objects.
        if (currentPlayerText.text.Equals("Player1's turn"))
        {
            GameObject obj = Instantiate(xPrefab, position, Quaternion.identity);
            _boardObjects[row, col] = obj;
            Debug.Log("Hello, my name is X");
        }
        if (currentPlayerText.text.Equals("Player2's turn"))
        {
            GameObject obj = Instantiate(oPrefab, position, Quaternion.identity);
            _boardObjects[row,col] = obj;
            Debug.Log("Hello, my name is O");
        }
    }
    
    private void UpdateCurrentPlayerText()
    {
        // update which player is currently playing
        if (currentPlayerText.text.Equals("Player1's turn"))
        {
            currentPlayerText.text = "Player2's turn";
        }
        if (currentPlayerText.text.Equals("Player2's turn"))
        {
            currentPlayerText.text = "Player1's turn";
        }
        if (_game._movesMade >= 9)
        {
            currentPlayerText.text = "Player1's turn";
        }
    }

    private void EndGame(int row, int col)
    {
        /* // update and display who won the game
         if (_boardObjects[row, 0] == _boardObjects[row, 1] && _boardObjects[row, 1] == _boardObjects[row, 2] && (_boardObjects[row, 0] == xPrefab || _boardObjects[row, 0] == oPrefab))
         {
             gameResultText.text = currentPlayerText + "Wins";
         }
         if (_boardObjects[0, col] == _boardObjects[1, col] && _boardObjects[1, col] == _boardObjects[2, col] && (_boardObjects[0, col] == xPrefab || _boardObjects[0, col] == oPrefab))
         {
             gameResultText.text = currentPlayerText + "Wins";
         }
         if (_boardObjects[0, 0] == _boardObjects[1, 1] && _boardObjects[1, 1] == _boardObjects[2, 2] && (_boardObjects[0, 0] == xPrefab || _boardObjects[0, 0] == oPrefab))
         {
             gameResultText.text = currentPlayerText + "Wins";
         }
         if (_boardObjects[0, 2] == _boardObjects[1, 1] && _boardObjects[1, 1] == _boardObjects[2, 0] && (_boardObjects[0, 2] == xPrefab || _boardObjects[0, 2] == oPrefab))
         {
             gameResultText.text = currentPlayerText + "Wins";
         }*/

        _game.CheckWinCondition(row, col);
        _game.GetGameResult();

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

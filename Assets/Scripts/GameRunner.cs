
using UnityEngine;
using TMPro;
using System;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine.Assertions.Must;

public class GameRunner : MonoBehaviour
{
    private TicTacToeGame _game;
    [SerializeField]private TMP_Text currentPlayerText;
    [SerializeField]private TMP_Text gameResultText;
    [SerializeField]private GameObject xPrefab;
    [SerializeField]private GameObject oPrefab;

    // This array will hold the instantiated board objects
    private GameObject[,] _boardObjects = new GameObject[3,3];

    private GameObject xClone;
    private GameObject oClone;

    private void Start()
    {
        //_game = new TicTacToeGame();
        //_game.InitializeGame();
        InitializeBoard();
        //UpdateCurrentPlayerText();
        gameResultText.text = "";
    }

    public void InitializeBoard()
    {
        //Clear the board
        Destroy(xClone);
        Destroy(oClone);
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
                if (_game.CurrentState == GameState.Draw)
                {
                    EndGame(row, col);
                }
                else
                {
                    UpdateCurrentPlayerText();
                }
            }
        }

    }

    private void UpdateBoard(int row, int col, Vector2 position)
    {
        // Check the game values and update the board by instantiating correct prefab objects.
        for (int i = 0; i < _boardObjects.Length; i++)
        {
            row = i / 3;
            col = i % 3;
            if (currentPlayerText.text.Equals("Player1's turn"))
            {
                xClone = Instantiate(xPrefab, position, Quaternion.identity);
            }
            else if (currentPlayerText.text.Equals("Player2's turn"))
            {
                oClone = Instantiate(oPrefab, position, Quaternion.identity);
            }
        }
        
        
    }
    
    private void UpdateCurrentPlayerText()
    {
        currentPlayerText.text = $"Current Player: {_game.CurrentPlayer}";
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

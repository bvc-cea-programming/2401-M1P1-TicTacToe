using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public enum Player
{
    None,
    X,
    O
}

public enum GameState
{
    Ongoing,
    Draw,
    Win
}

// convert this class into an abstract class done
public abstract class Game
{

    // Why do we use protected here?
    protected Player currentPlayer;
    protected GameState gameState;

    // Public properties for external access
    public Player CurrentPlayer => currentPlayer;
    public GameState CurrentState => gameState;

    // Create a constructor to initialize the game
    public abstract void InitializeGame();
    public abstract bool MakeMove(int row, int col);
    public abstract bool CheckWinCondition(int row, int col);
    public abstract bool CheckDrawCondition();
    public abstract string GetGameResult();

    // Create the following abstract methods for the following
    // 1. InitializeGame   done
    // 2. MakeMove - returns true if the move was successful, parameters should be the row and column of the move done
    // 3. CheckWinCondition - returns true if the win condition is met, parameters should be the row and column of the move done
    // 4. CheckDrawCondition - returns true if the draw condition is met done
    // 5. GetGameResult - returns the result of the game done


    // What does this method do?
    protected void SwitchPlayer()
    {
        currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
    }
  



}

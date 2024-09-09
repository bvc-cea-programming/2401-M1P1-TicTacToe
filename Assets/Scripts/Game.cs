using System;
using Unity.VisualScripting;

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

// convert this class into an abstract class
public abstract class Game
{
    // Why do we use protected here?
    protected Player currentPlayer; //to specify it is used only by the set type of info?
    protected GameState gameState;

    // Public properties for external access
    public Player CurrentPlayer => currentPlayer;
    public GameState CurrentState => gameState;

    // Create a constructor to initialize the game
    public Game()
    {
        InitializeGame();
    }

    // Create the following abstract methods for the following
    // 1. InitializeGame
    public abstract void InitializeGame();
    // 2. MakeMove - returns true if the move was successful, parameters should be the row and column of the move
    public abstract bool MakeMove(int row, int col);
    // 3. CheckWinCondition - returns true if the win condition is met, parameters should be the row and column of the move
    public abstract bool CheckWinCondition(int row, int col);
    // 4. CheckDrawCondition - returns true if the draw condition is met
    public abstract bool CheckDrawCondition();
    // 5. GetGameResult - returns the result of the game
    public abstract string GetGameResult(); 


    // What does this method do? 
    protected void SwitchPlayer()
    {
        currentPlayer = currentPlayer == Player.X ? Player.O : Player.X; //changes turn between players 
    }
}
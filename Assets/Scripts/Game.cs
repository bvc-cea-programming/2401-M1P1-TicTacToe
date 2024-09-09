using System;

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
public class Game
{
    // Why do we use protected here?    A: protected variables can be only used for the classes that are internal to the owner class
    protected Player currentPlayer;
    protected GameState gameState;

    // Public properties for external access
    public Player CurrentPlayer => currentPlayer;
    public GameState CurrentState => gameState;

    // Create a constructor to initialize the game
    

    // Create the following abstract methods for the following
    // 1. InitializeGame
    // 2. MakeMove - returns true if the move was successful, parameters should be the row and column of the move
    // 3. CheckWinCondition - returns true if the win condition is met, parameters should be the row and column of the move
    // 4. CheckDrawCondition - returns true if the draw condition is met
    // 5. GetGameResult - returns the result of the game
    

    // What does this method do?
    protected void SwitchPlayer()
    {
        currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
    }
}
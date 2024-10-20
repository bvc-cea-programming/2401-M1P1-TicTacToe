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
public abstract class Game
{
    // Why do we use protected here?
    // A: Protected variables can be only used for the classes that are internal to the owner class,
    //    since tic tac toe game requires multiple players,
    //    we need to make the player and the state variables to be accessible from internal classes which are all of the different player classes
    protected Player currentPlayer;
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
    // 2. MakeMove - returns true if the move was successful, parameters should be the row and column of the move
    // 3. CheckWinCondition - returns true if the win condition is met, parameters should be the row and column of the move
    // 4. CheckDrawCondition - returns true if the draw condition is met
    // 5. GetGameResult - returns the result of the game

    public abstract void InitializeGame();
    public abstract bool MakeMove(int row, int col);
    public abstract bool CheckWinCondition(int row, int col);
    protected abstract bool CheckDrawCondition();
    public abstract string GetGameResult();

    // What does this method do?
    public void SwitchPlayer()
    {
        currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
        // A: This method is used to switch the player to another if the player is done the move.
        //    this method will work to be this way:
        //    if currentPlayer is equal to X, set player to O; else if current player is equal to O, set player to X.
    }
}
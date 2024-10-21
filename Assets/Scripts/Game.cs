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
    // Why do we use protected here? - It allows for derived classes to access these fields.
    protected Player currentPlayer;
    protected GameState gameState;

    // Public properties for external access
    public Player CurrentPlayer => currentPlayer;
    public GameState CurrentState => gameState;

    // Create a constructor to initialize the game
    public Game()
    {
        currentPlayer = Player.X;
        gameState = GameState.Ongoing;
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
    public abstract bool CheckDrawCondition();
    public abstract string GetGameResult();

    

    // What does this method do? - This method switches the current player
    protected void SwitchPlayer()
    {
        currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
    }
}
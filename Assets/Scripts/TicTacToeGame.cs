using System;

// Inherit this class from the Game class. Complete the tasks in the Game Class before making changes here.
public class TicTacToeGame : Game
{
    // This game uses the Enum "Player" to keep track of the move. We can use a 2D array to keep track of the board.
    private Player[,] _board;
    private int _movesMade;

    public TicTacToeGame() : base()
    {
        InitializeGame();
    }

    // override the method that Initializes the game. In this case, it initializes the board.
    public override void InitializeGame()
    {
        // Set the default player to Player X and set the game state to Ongoing
        _board = new Player[3, 3];
        currentPlayer = Player.X;
        gameState = GameState.Ongoing;
        _movesMade = 0;
    }

    // override the MakeMove method you created in the Game class. Add your code after each comment.
    public override bool MakeMove(int row, int col)
    {
        //This method will perform the follwing

        // if the gamestate is ongoing, return false
        if (gameState != GameState.Ongoing)
            return false;
        
        // if the move is not valid, return false
        if (!IsValidMove(row, col))
            return false;

        // update the cell value to the current player value
        _board[row, col] = currentPlayer;


        // increment the number of moves
        _movesMade++;

        // Check for win or draw conditions
        if (CheckWinCondition(row, col))
        {
            // Set the game state to Win
            gameState = GameState.Win;
        }
        else if (CheckDrawCondition())
        {
            // Set the game state to Draw
            gameState = GameState.Draw;
        }
        else
        {
            // Uncomment below line to switch the player, make sure you inherit from the Game class
            SwitchPlayer();
        }

        return true;
    }

    // This method will check if the move is valid, first it checks if the row and column are valid. Then it checks if the cell is not already occupied.
    private bool IsValidMove(int row, int col)
    {
        if (row < 0 || row > 2 || col < 0 || col > 2)
            return false;
        if (_board[row, col] != Player.None)
            return false;
        return true;
    }

    // Override the CheckWinCondition method from the game class
    public override bool CheckWinCondition(int row, int col)
    {
        // Use  this method to check if the move is a win. It will return true if the move is a win. Otherwise, it will return false.
        // Check row
        if (_board[row, 0] == currentPlayer && _board[row, 1] == currentPlayer && _board[row, 2] == currentPlayer)
            return true;

        // Check column
        if (_board[0, col] == currentPlayer && _board[1, col] == currentPlayer && _board[2, col] == currentPlayer)
            return true;

        // Check main diagonal
        if (_board[0, 0] == currentPlayer && _board[1, 1] == currentPlayer && _board[2, 2] == currentPlayer)
            return true;

        // Check anti-diagonal
        if (_board[0, 2] == currentPlayer && _board[1, 1] == currentPlayer && _board[2, 0] == currentPlayer)
            return true;

        return false; // No win condition met
    }

    // Override the CheckDrawCondition method from the game class
    public  override bool CheckDrawCondition()
    {
        // The game is a draw if all moves have been made without a win
        return _movesMade == 9;
    }

    // Override the GetGameResult method from the game class
    public override string GetGameResult()
    {
        // In a switch case statement, check the game state and return the appropriate string.
        // Uncomment the switch statement below, and add your code replacing the '...'
        switch (gameState)
        {
            case GameState.Win:
                return $"Player {currentPlayer} wins!";
            case GameState.Draw:
                return "The game is a draw.";
            case GameState.Ongoing:
            default:
                return "The game is ongoing.";
        }
    }

    // Additional method to get the player at a specific position
    public Player GetPlayerAtPosition(int row, int col)
    {
        if (row < 0 || row > 2 || col < 0 || col > 2)
            throw new ArgumentOutOfRangeException("Position out of bounds.");
        return _board[row, col];
    }

    // Method to reset the game
    public void ResetGame()
    {
        InitializeGame();
    }
}

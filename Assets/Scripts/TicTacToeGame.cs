using System;

// Inherit this class from the Game class. Complete the tasks in the Game Class before making changes here.
public class TicTacToeGame
{
    // This game uses the Enum "Player" to keep track of the move. We can use a 2D array to keep track of the board.
    private Player[,] _board;
    private int _movesMade;

    public TicTacToeGame() : base()
    {
    }

    // override the method that Initializes the game. In this case, it initializes the board.
    public void InitializeGame()
    {
        _board = new Player[3, 3];
        
        // Set the default player to Player X and set the game state to Ongoing
        
        _movesMade = 0;
    }

    // override the MakeMove method you created in the Game class. Add your code after each comment.
    public bool MakeMove(int row, int col)
    {
        //This method will perform the follwing
        
        // if the gamestate is ongoing, return false
        
        // if the move is not valid, return false
        
        // update the cell value to the current player value
        
        // increment the number of moves
        

        if (CheckWinCondition(row, col))
        {
            // Set the game state to Win
        }
        else if (CheckDrawCondition())
        {
            // Set the game state to Draw
        }
        else
        {
            // Uncomment below line to switch the player, make sure you inherit from the Game class
            //SwitchPlayer();
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
    private bool CheckWinCondition(int row, int col)
    {
        // Use  this method to check if the move is a win. It will return true if the move is a win. Otherwise, it will return false.
        // Check row
        

        // Check column
        

        // Check diagonal
        

        // Check anti-diagonal
        

        return false;
    }

    // Override the CheckDrawCondition method from the game class
    private bool CheckDrawCondition()
    {
        // Use this method to check if the game is a draw. It will return true if the game is a draw. Otherwise, it will return false.
        // One way to check that is to check if the number of moves made is equal to 9.
        return false; // replace this with your code
    }

    // Override the GetGameResult method from the game class
    public string GetGameResult()
    {
        // In a switch case statement, check the game state and return the appropriate string.
        // Uncomment the switch statement below, and add your code replacing the '...'
        /*switch (...)
        {
            case ...
                return $"Player {currentPlayer} wins!";
            case ...
                return "The game is a draw.";
            case ...
            default:
                return "The game is ongoing.";
        }*/
        return "";
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

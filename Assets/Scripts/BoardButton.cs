using UnityEngine;

public class BoardButton : MonoBehaviour
{
    [SerializeField] private int row;
    [SerializeField] private int col;
    [SerializeField] private GameRunner gameRunner;

    public void Interact()
    {
        // This method should communicate with the game runner, and pass in the row and column of the button that was clicked.

        if (gameRunner != null)
        {
            gameRunner.OnBoardButtonClick(row, col, transform.position);
        }
        else
        {
            Debug.LogError("GameRunner is not assigned in BoardButton!");
        }
    }
}
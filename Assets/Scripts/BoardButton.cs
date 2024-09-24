using UnityEngine;
using UnityEngine.UIElements;

public class BoardButton : MonoBehaviour
{
    [SerializeField]private int row;
    [SerializeField]private int col;
    [SerializeField] private GameRunner gameRunner;
    
    public void Interact(Vector2 pointerPosition)
    {
        // This method should communicate with the game runner, and pass in the row and column of the button that was clicked.
        gameRunner.OnBoardButtonClick(row, col, transform.position);
        Debug.Log(row + " " + col);

    }
}

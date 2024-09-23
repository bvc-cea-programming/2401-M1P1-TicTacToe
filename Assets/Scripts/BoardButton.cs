using UnityEngine;

public class BoardButton : MonoBehaviour
{
    [SerializeField]private int row;
    [SerializeField]private int col;
    [SerializeField] private GameRunner gameRunner;
    
    public void Interact()
    {
        Vector3 position = transform.position;
        gameRunner.OnBoardButtonClick(row - 1, col - 1, position);

        // This method should communicate with the game runner, and pass in the row and column of the button that was clicked.
    }
}

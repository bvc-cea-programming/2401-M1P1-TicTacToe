using UnityEngine;

public class BoardButton : MonoBehaviour
{
    [SerializeField]private int row;
    [SerializeField]private int col;
    [SerializeField] private GameRunner gameRunner;
    
    public void Interact()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.z);
        // This method should communicate with the game runner, and pass in the row and column of the button that was clicked.
        gameRunner.OnBoardButtonClick(row - 1, col - 1, pos);
        Debug.Log(pos);
    }
}

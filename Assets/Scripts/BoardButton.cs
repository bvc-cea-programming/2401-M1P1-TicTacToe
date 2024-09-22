using UnityEngine;

public class BoardButton : MonoBehaviour
{
    [SerializeField]private int row;
    [SerializeField]private int col;
    [SerializeField] private GameRunner gameRunner;
    
    public void Interact()
    {
        Debug.Log("HELA");
        // This method should communicate with the game runner, and pass in the row and column of the button that was clicked.
        Vector2 buttonPosition = new Vector2();
        {
            buttonPosition.x = transform.position.x;
            buttonPosition.y = transform.position.z;
        }
        gameRunner.OnBoardButtonClick(row, col, buttonPosition);
    }
}

using UnityEngine;

public class BoardButton : MonoBehaviour
{
    [SerializeField]private int row;
    [SerializeField]private int col;
    [SerializeField] private GameRunner gameRunner;
    
    public void Interact()
    {
        // This method should communicate with the game runner, and pass in the row and column of the button that was clicked.

	gameRunner.OnBoardButtonClick(row -1, col -1,new Vector2(gameObject.transform.position.x,gameObject.transform.position.z));
    }
}

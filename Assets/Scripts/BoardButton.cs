using UnityEngine;

public class BoardButton : MonoBehaviour
{
    [SerializeField]public int row;//when finish change back to private
    [SerializeField]public int col;
    [SerializeField]private GameRunner gameRunner;

    public void Interact(int row,int col,Vector3 position)
    {
        // This method should communicate with the game runner
        // pass in the row and column of the button that was clicked.===from game runner? or boardinteractor I get in the boardinteractor
        
        gameRunner = FindObjectOfType<GameRunner>();
        BoardInteractor boardInteractor= FindObjectOfType<BoardInteractor>();
     
       gameRunner.OnBoardButtonClick( row,col,position);


    }
}

using UnityEngine;

public class BoardInteractor : MonoBehaviour
{
    private Camera _mainCam;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRayAndInteract(Input.mousePosition);
        }
    }
    
    private void CastRayAndInteract(Vector2 pointerPosition)
    {
        // Cast a physics ray from the camera to the pointer position
        // Check for a Board Button and interact with it
    }
}

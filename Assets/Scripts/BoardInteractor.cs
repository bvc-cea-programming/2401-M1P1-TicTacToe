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
        Ray ray = _mainCam.ScreenPointToRay(pointerPosition);
        RaycastHit hit;

        // Check for a Board Button and interact with it
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out BoardButton _boardButton))
            {
                _boardButton.Interact();
            }
        }
    }
}

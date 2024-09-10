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
        Ray ray = _mainCam.ScreenPointToRay(pointerPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);
            BoardButton boardButton = hit.collider.GetComponent<BoardButton>();
            if (boardButton != null)
            {
                boardButton.Interact();
            }
        }
    }
}
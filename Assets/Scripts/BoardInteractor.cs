using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;

public class BoardInteractor : MonoBehaviour
{
    private Camera _mainCam;
    public Vector3 hitPosition;
    public GameObject currentHitObject;
    public int currentRow;
    public int currentCol;


    [SerializeField] private GameObject xPrefab;


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
        RaycastHit hit;
        Ray ray = _mainCam.ScreenPointToRay(pointerPosition);
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            hitPosition = hit.transform.position;
            currentHitObject = hit.collider.gameObject;

        }
       
        
        // Check for a Board Button and interact with it
        BoardButton boardButton = currentHitObject.GetComponent<BoardButton>();
        if (boardButton != null)
        {
            currentRow = boardButton.row - 1;
            currentCol = boardButton.col - 1;
       
            boardButton.Interact(currentRow, currentCol, hitPosition);
        }
        

    }






}


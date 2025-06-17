using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private InputAction mouseClick;
    [SerializeField] private float mouseDragSpeed = .1f;

    private Camera mainCamera;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += MousePressed;
    }

    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseClick.Disable();
    }

    private void MousePressed(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        if (hit2D.collider != null)
            {
                if (hit2D.collider.gameObject.CompareTag("Draggable") || hit2D.collider.gameObject.layer == LayerMask.NameToLayer("Draggable") || hit2D.collider.gameObject.GetComponent<IDrag>() != null)
                {
                    StartCoroutine(DragUpdate(hit2D.collider.gameObject));
                }

            }

    }

    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        clickedObject.TryGetComponent<IDrag>(out var iDragComponent);
        iDragComponent?.onStartDrag();

        float initialDistance = Vector3.Distance(new Vector3(clickedObject.transform.position.x, clickedObject.transform.position.y, 0f), new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 0f));
        while (mouseClick.ReadValue<float>() != 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position, new Vector3(ray.GetPoint(initialDistance).x, ray.GetPoint(initialDistance).y, clickedObject.transform.position.z), ref velocity, mouseDragSpeed);
            yield return null;
        }
        iDragComponent?.onEndDrag();
    }

}


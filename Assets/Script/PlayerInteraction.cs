using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private float interactionDistance = 3.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Ray ray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);

        if(Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            IInteractable interacable = hit.collider.GetComponent<IInteractable>();
            if(interacable != null)
            {
                interacable.Interaction();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if(interactable != null && other.gameObject.CompareTag("DoorSensor"))
        {
            interactable.Interaction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null && other.gameObject.CompareTag("DoorSensor"))
        {
            interactable.Interaction();
        }
    }
}

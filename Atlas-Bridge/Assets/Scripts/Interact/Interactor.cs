using UnityEngine;

public class Interactor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IInteractable>() !=null)
        {
            var interactable = other.GetComponent<IInteractable>();
            interactable.Interact();
        }
    }
}

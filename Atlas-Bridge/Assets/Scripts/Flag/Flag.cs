using UnityEngine;

public class Flag : MonoBehaviour,IInteractable
{
    [SerializeField] private Transform backpackPosition;
    [SerializeField] private GameObject flagPrefab;

    public void Interact()
    {
        Debug.Log("flag interact");
        SetParent();
    }
    private void SetParent()
    {
        //player pick up flag in back
        transform.SetParent(backpackPosition);
    }
}

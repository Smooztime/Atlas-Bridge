using Unity.VisualScripting;
using UnityEngine;

public class RollingItem :MonoBehaviour, IInteractable
{
    //rolling barrel
    public void Interact()
    {
        Debug.Log("get rolling interact");
        //if hit the player will die the player
        GameManager.Instance.GameOver();
        //make player to to spawn location
    }
}

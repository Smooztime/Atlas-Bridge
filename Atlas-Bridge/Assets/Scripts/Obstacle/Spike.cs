using UnityEngine;

public class Spike : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        SpikeDiePlayer();

    }

    private void SpikeDiePlayer()
    {
        Debug.Log("spikes die the player");
        //play die animation give spawn location
    }
}

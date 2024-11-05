using Unity.VisualScripting;
using UnityEngine;

public class RollingItem :Obstacles, IInteractable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (other.gameObject.GetComponent<PlayerController>()._isControllerActive)
            {
                Debug.Log("Rolling Star");
                other.gameObject.GetComponent<KnockBack>().KnockBackFromStuffs(other.transform, obstaclesSO.ObstacleForce);
            }
        }
    }
}

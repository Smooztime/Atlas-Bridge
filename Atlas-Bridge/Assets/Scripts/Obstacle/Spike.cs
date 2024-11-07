using UnityEngine;

public class Spike : Obstacles
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            if(other.gameObject.GetComponent<PlayerController>()._isControllerActive)
            {
                Debug.Log("Spike made holes on your body");
                other.gameObject.GetComponent<KnockBack>().KnockBackFromStuffs(this.gameObject.transform, obstaclesSO.ObstacleForce);
            }
        }
    }
}

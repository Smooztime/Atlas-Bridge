using UnityEngine;

public class Explosion : Obstacles
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (other.gameObject.GetComponent<PlayerController>()._isControllerActive)
            {
                Debug.Log("Bomb yourself");
                other.gameObject.GetComponent<KnockBack>().KnockBackFromStuffs(this.gameObject.transform, obstaclesSO.ObstacleForce);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (other.gameObject.GetComponent<PlayerController>()._isControllerActive)
            {
                Debug.Log("Bomb yourself");
                other.gameObject.GetComponent<KnockBack>().KnockBackFromStuffs(this.gameObject.transform, obstaclesSO.ObstacleForce);
            }
        }
    }
}

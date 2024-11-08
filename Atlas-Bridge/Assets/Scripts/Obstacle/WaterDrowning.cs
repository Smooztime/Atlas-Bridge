using UnityEngine;

public class WaterDrowning : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            other.gameObject.GetComponent<PlayerController>()._isDrowning = true;
            other.gameObject.GetComponent<SpawnPlayer>().PlayerDrowning();
        }
    }
}

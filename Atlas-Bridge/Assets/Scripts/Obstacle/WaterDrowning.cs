using UnityEngine;

public class WaterDrowning : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            other.gameObject.GetComponent<SpawnPlayer>().PlayerDrowning();
        }
    }
}

using UnityEngine;

public class WaterDropSpawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            var _flag = other.gameObject.GetComponentsInChildren<Flag>();
            if (_flag != null)
            {
                foreach (var flag in _flag)
                {
                    flag.FlagDropAtPosition(this.transform);
                    Debug.Log("flag will drop here");
                }
            }
        }
            
    }
}

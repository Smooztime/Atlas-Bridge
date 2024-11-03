using Unity.VisualScripting;
using UnityEngine;

public class RollingItem :MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<FlagHolder>())
        {
            FlagHolder flagHolder = other.gameObject.GetComponent<FlagHolder>();
            Flag flag =other.gameObject.GetComponentInChildren<Flag>();
            if (flag != null) 
            {
                flag.FlagFallOnGround();
                flagHolder.RemoveFlag(flag);
            }
        }
    }
}

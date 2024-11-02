using Unity.VisualScripting;
using UnityEngine;

public class RollingItem :MonoBehaviour, IInteractable
{
    //rolling barrel
    public float rollSpeed = 5f;
    void Interact()
    {
        //if hit the player will die the player

        //make player to to spawn location

    }
   

    void FixedUpdate()
    {

        transform.position += Vector3.left * rollSpeed * Time.deltaTime;

        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }

}

using Unity.VisualScripting;
using UnityEngine;

public class RollingItem :MonoBehaviour, IInteractable
{
    //rolling barrel
    public float rollSpeed = 5f;
    public void Interact()
    {
        //if hit the player will die the player
        Debug.Log("get rolling interact");
        GameManager.Instance.GameOver();
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

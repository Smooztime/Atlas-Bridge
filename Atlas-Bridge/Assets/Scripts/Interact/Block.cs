using UnityEngine;

public class Block : MonoBehaviour,IInteractable
{
    [Header(" look change")]
    private Renderer render;
    [SerializeField] private Material red;
    [SerializeField] private Material blue;
    private FlagHolder player;
    private void Start()
    {
        render = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FlagHolder>())
        {
            player = other.gameObject.GetComponent<FlagHolder>();
            //light the block with player color
            if (player.flagHolderType == FlagHolder.FlagHolderType.blueHolder)
            {
                render.material = blue;
            }
            else if(player.flagHolderType == FlagHolder.FlagHolderType.redHolder)
            {
                render.material = red;
            }
        }
    }
    public void Interact()
    {
        //light the block with player color
       // Debug.Log("lighet on now");
    }
}

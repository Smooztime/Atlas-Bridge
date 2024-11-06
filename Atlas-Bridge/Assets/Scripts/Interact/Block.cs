using UnityEngine;

public class Block : MonoBehaviour,IInteractable
{
    [Header(" look change")]
    private Renderer render;
    [SerializeField] private Material red;
    [SerializeField] private Material blue;
   
    private FlagHolder player;
    private bool isBlue;
    private bool isRed;
   
    private void Start()
    {
        render = GetComponent<Renderer>();
        isRed = false;
        isBlue = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FlagHolder>())
        {
            player = other.gameObject.GetComponent<FlagHolder>();
            //light the block with player color
            if (player.flagHolderType == FlagHolder.FlagHolderType.blueHolder)
            {
                if (isBlue)
                {
                    return;
                }
                else if (isRed)
                {
                    GameManager.Instance.blueBlocks.Add(this);
                    render.material = blue;
                    isBlue = true;
                    GameManager.Instance.RemoveRedBlock(this);
                   
                }
                else
                {
                    render.material = blue;
                    isBlue = true;
                    GameManager.Instance.blueBlocks.Add(this);
                }
            }
            else if(player.flagHolderType == FlagHolder.FlagHolderType.redHolder)
            {
                if (isRed)
                {
                    return;
                }
                else if (isBlue)
                {
                    GameManager.Instance.redBlocks.Add(this);
                    render.material = red;
                    isRed = true;
                    GameManager.Instance.RemoveBlueBlock(this);
                }
                else
                {
                    render.material = red;
                    isRed = true;
                    GameManager.Instance.redBlocks.Add(this);
                }
            }
        }
    }
    public void Interact()
    {
        //light the block with player color
       // Debug.Log("lighet on now");
    }
}

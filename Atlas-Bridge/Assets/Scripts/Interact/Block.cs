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
                    isRed = false;
                    GameManager.Instance.RemoveRedBlock(this); 
                }
                else
                {
                    render.material = blue;
                    isBlue = true;
                    isRed = false;
                    GameManager.Instance.blueBlocks.Add(this);
                    Debug.Log("blue" + GameManager.Instance.blueBlocks.Count);
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
                    isBlue = false;
                    GameManager.Instance.RemoveBlueBlock(this);
                }
                else
                {
                    render.material = red;
                    isRed = true;
                    isBlue = false;
                    GameManager.Instance.redBlocks.Add(this);
                }
            }
        }
    }
}

using UnityEngine;
using static Flag;
using static FlagHolder;

public class BaseTower : MonoBehaviour
{
    [Header("flag Position")]
    [SerializeField] protected Transform _towerFlagPosition;

    [Header("tower look change")]
    [SerializeField] private Material red;
    [SerializeField] private Material blue;

    private Flag[] Flags;
    private Flag removeFlag;
    private FlagType flagType;
    private FlagHolderType flagHolderType;
    private FlagHolder player;

    public TowerType towerType; 
    public enum TowerType
    {
        redTower,
        blueTower
    }

    private void OnTriggerEnter(Collider other)
    {
        //tower got player with flagHolder
        if (other.GetComponentInChildren<Flag>())
        {
            Flag[] flags = other.GetComponentsInChildren<Flag>(); 
            player = other.GetComponent<FlagHolder>();
            //red tower with red player and blue holder 
            if (this.towerType == TowerType.redTower && player.flagHolderType == FlagHolder.FlagHolderType.blueHolder)
            {
                foreach (Flag flag in flags)
                {
                    if (flag.Type == Flag.FlagType.flagBlue)
                    {
                        Debug.Log("before:" +flags.Length);
                        SetFlagPosition(flag.gameObject);
                        SoundManagerNew.Instance.PlaySFX("AchieveSfx1");
                        removeFlag = flag;
                        player.RemoveFlag(removeFlag);
                        LightBlueTower(blue, player);
                        break; 
                    }
                }
            }
            //blue tower with red player and red flag
            else if (this.towerType == TowerType.blueTower && player.flagHolderType == FlagHolder.FlagHolderType.redHolder)
            {
                foreach (Flag flag in flags)
                {
                    if (flag.Type == Flag.FlagType.flagRed)
                    {
                        Debug.Log("before:" + flags.Length);
                        SetFlagPosition(flag.gameObject);
                        SoundManagerNew.Instance.PlaySFX("AchieveSfx1");
                        removeFlag =flag;
                        player.RemoveFlag(removeFlag);
                        LightBlueTower(red,player);
                        break;
                    }
                }
            }
            else return;
        }
    }
    private void SetFlagPosition(GameObject flagObject)
    {
        flagObject.transform.SetParent(this.gameObject.transform);
        flagObject.transform.position = _towerFlagPosition.position;
    }
    private void LightBlueTower(Material value,FlagHolder flagHolder)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = value;
        GameManager.Instance.WinHappen(flagHolder);

    }

}

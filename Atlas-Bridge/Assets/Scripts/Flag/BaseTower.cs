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

    private Flag flagScript;
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
        //tower got player with flag
        if (other.GetComponentInChildren<Flag>())
        {
            flagScript = other.GetComponentInChildren<Flag>(); 
           // Debug.Log("flay type is:" + flagScript.Type);

            player = other.GetComponent<FlagHolder>();

            //Debug.Log("player type is:" + player.flagHolderType);

            //red tower with blue player and blue flag
            if (this.towerType == TowerType.redTower && player.flagHolderType == FlagHolder.FlagHolderType.blueHolder)
            {
                if (flagType == Flag.FlagType.flagBlue || player.flagsHolding.Count==2)
                {
                    Debug.Log(" red tower interact with flag");
                    SetFlagPosition(flagScript.gameObject);
                    LightBlueTower(blue);
                }
            }
            //blue tower with red player and red flag
            else if (this.towerType == TowerType.blueTower && player.flagHolderType == FlagHolder.FlagHolderType.redHolder)
            {
                if (flagType == Flag.FlagType.flagRed || player.flagsHolding.Count==2)
                {
                    Debug.Log(" blue tower interact with flag");
                    SetFlagPosition(flagScript.gameObject);
                    LightBlueTower(red);
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
    private void LightBlueTower(Material value)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = value;
    }

}
